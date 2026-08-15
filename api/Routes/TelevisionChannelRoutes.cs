using api.Models;
using api.Utils;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using static api.Utils.Functions;
using static api.Utils.Messages.EndpointMetadata;
using TVChannelMetadataMessages = api.Utils.Messages.EndpointMetadata.TelevisionChannelEndpoint;
using Microsoft.AspNetCore.Mvc;

namespace api.Routes
{
    public static class TelevisionChannelRoutes
    {
        public static void RegisterTelevisionChannelAPI(WebApplication app)
        {
            const string API_TVCHANNEL_COMPLETE = $"{Util.API_ROUTE}{Util.API_VERSION}{Util.TELEVISION_CHANNEL_ROUTE}";
            const string API_TVCHANNEL_TAG = "TelevisionChannel";

            // Group and tags usage
            IEndpointRouteBuilder group = app
                .MapGroup(API_TVCHANNEL_COMPLETE)
                .WithTags(API_TVCHANNEL_TAG)
                .CacheOutput()
                .RequireRateLimiting(Util.PublicRateLimitPolicy);

            group.MapGet(string.Empty, async (DBContext db,
                [FromQuery, SwaggerParameter(Description = Swagger.sortedBy)] string? sortBy,
                [FromQuery, SwaggerParameter(Description = Swagger.sortDirection)] string? sortDirection) =>
            {
                var queryChannels = db.TelevisionChannels
                    .Include(p => p.City)
                    .AsQueryable();

                (queryChannels, var isValidSort) = ApplySorting(queryChannels, sortBy, sortDirection);

                if (!isValidSort)
                {
                    return Results.BadRequest(RequestMessages.BadRequest);
                }

                var listChannels = await queryChannels.ToListAsync();
                return Results.Ok(listChannels);
            })
            .Produces<List<TelevisionChannel>?>(200)
            .WithMetadata(new SwaggerOperationAttribute(
                summary: TVChannelMetadataMessages.MESSAGE_TVCHANNEL_LIST_SUMMARY,
                description: TVChannelMetadataMessages.MESSAGE_TVCHANNEL_LIST_DESCRIPTION
                ));

            group.MapGet("{id}", async (int id, DBContext db) =>
            {
                if (id <= 0)
                {
                    return Results.BadRequest();
                }

                var channel = await db.TelevisionChannels
                    .Include(p => p.City)
                    .SingleOrDefaultAsync(p => p.Id == id);
                if (channel is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(channel);
            })
            .Produces<TelevisionChannel?>(200)
            .WithMetadata(new SwaggerOperationAttribute(
                summary: TVChannelMetadataMessages.MESSAGE_TVCHANNEL_BYID_SUMMARY,
                description: TVChannelMetadataMessages.MESSAGE_TVCHANNEL_BYID_DESCRIPTION
                ));

            group.MapGet("name/{name}", (string name, DBContext db) =>
            {
                var search = name.Trim().ToUpper();
                var channels = db.TelevisionChannels
                    .Include(p => p.City)
                    .Where(x => x.Name.ToUpper().Contains(search))
                    .ToList();
                return Results.Ok(channels);
            })
            .Produces<List<TelevisionChannel>?>(200)
            .WithMetadata(new SwaggerOperationAttribute(
                summary: TVChannelMetadataMessages.MESSAGE_TVCHANNEL_BYNAME_SUMMARY,
                description: TVChannelMetadataMessages.MESSAGE_TVCHANNEL_BYNAME_DESCRIPTION
                ));

            group.MapGet("search/{keyword}", (string keyword, DBContext db) =>
            {
                string wellFormedKeyword = keyword.Trim().ToUpper().Normalize();
                var dbChannels = db.TelevisionChannels.Include(p => p.City).ToList();
                var channels = Functions.FilterObjectListPropertiesByKeyword<TelevisionChannel>(dbChannels, wellFormedKeyword);
                return Results.Ok(channels);
            })
            .Produces<List<TelevisionChannel>>(200)
            .WithMetadata(new SwaggerOperationAttribute(
                summary: TVChannelMetadataMessages.MESSAGE_TVCHANNEL_SEARCH_SUMMARY,
                description: TVChannelMetadataMessages.MESSAGE_TVCHANNEL_SEARCH_DESCRIPTION
                ));

            group.MapGet("pagedList", async ([AsParameters] PaginationModel pagination, DBContext db) =>
            {
                if (pagination.Page <= 0 || pagination.PageSize <= 0)
                {
                    return Results.BadRequest();
                }

                var sortBy = pagination.SortBy ?? string.Empty;
                var sortDirectionStr = pagination.SortDirection?.ToString() ?? string.Empty;
                var queryChannels = db.TelevisionChannels
                    .Include(p => p.City)
                    .AsQueryable();

                (queryChannels, var isValidSort) = ApplySorting(queryChannels, sortBy, sortDirectionStr);

                if (!isValidSort)
                {
                    return Results.BadRequest(RequestMessages.BadRequest);
                }

                var totalRecords = await queryChannels.CountAsync();

                var pagedChannels = await queryChannels
                    .Skip((pagination.Page - 1) * pagination.PageSize)
                    .Take(pagination.PageSize)
                    .ToListAsync();

                var paginationResponse = new PaginationResponseModel<TelevisionChannel>
                {
                    Page = pagination.Page,
                    PageSize = pagination.PageSize,
                    TotalRecords = totalRecords,
                    Data = pagedChannels
                };

                return Results.Ok(paginationResponse);
            })
            .Produces<PaginationResponseModel<TelevisionChannel>>(200)
            .WithMetadata(new SwaggerOperationAttribute(
                summary: TVChannelMetadataMessages.MESSAGE_TVCHANNEL_PAGEDLIST_SUMMARY,
                description: TVChannelMetadataMessages.MESSAGE_TVCHANNEL_PAGEDLIST_DESCRIPTION
                ));
        }
    }
}
