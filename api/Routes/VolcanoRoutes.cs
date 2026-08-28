using api.Models;
using api.Utils;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using static api.Utils.Functions;
using static api.Utils.Messages.EndpointMetadata;
using VolcanoMetadataMessages = api.Utils.Messages.EndpointMetadata.VolcanoEndpoint;
using Microsoft.AspNetCore.Mvc;

namespace api.Routes
{
    public static class VolcanoRoutes
    {
        public static void RegisterVolcanoAPI(WebApplication app)
        {
            const string API_VOLCANO_COMPLETE = $"{Util.API_ROUTE}{Util.API_VERSION}{Util.VOLCANO_ROUTE}";
            const string API_VOLCANO_TAG = "Volcano";

            // Group and tags usage
            IEndpointRouteBuilder group = app
                .MapGroup(API_VOLCANO_COMPLETE)
                .WithTags(API_VOLCANO_TAG)
                .CacheOutput()
                .RequireRateLimiting(Util.PublicRateLimitPolicy);

            group.MapGet(string.Empty, async (DBContext db,
                [FromQuery, SwaggerParameter(Description = Swagger.sortedBy)] string? sortBy,
                [FromQuery, SwaggerParameter(Description = Swagger.sortDirection)] string? sortDirection) =>
            {
                var queryVolcanoes = db.Volcanoes
                    .Include(p => p.Department)
                    .Include(p => p.City)
                    .AsQueryable();

                (queryVolcanoes, var isValidSort) = ApplySorting(queryVolcanoes, sortBy, sortDirection);

                if (!isValidSort)
                {
                    return Results.BadRequest(RequestMessages.BadRequest);
                }

                var listVolcanoes = await queryVolcanoes.ToListAsync();
                return Results.Ok(listVolcanoes);
            })
            .Produces<List<Volcano>?>(200)
            .WithMetadata(new SwaggerOperationAttribute(
                summary: VolcanoMetadataMessages.MESSAGE_VOLCANO_LIST_SUMMARY,
                description: VolcanoMetadataMessages.MESSAGE_VOLCANO_LIST_DESCRIPTION
                ));

            group.MapGet("{id}", async (int id, DBContext db) =>
            {
                if (id <= 0)
                {
                    return Results.BadRequest();
                }

                var volcano = await db.Volcanoes
                    .Include(p => p.Department)
                    .Include(p => p.City)
                    .SingleOrDefaultAsync(p => p.Id == id);

                if (volcano is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(volcano);
            })
            .Produces<Volcano?>(200)
            .WithMetadata(new SwaggerOperationAttribute(
                summary: VolcanoMetadataMessages.MESSAGE_VOLCANO_BYID_SUMMARY,
                description: VolcanoMetadataMessages.MESSAGE_VOLCANO_BYID_DESCRIPTION
                ));

            group.MapGet("name/{name}", (string name, DBContext db) =>
            {
                var search = name.Trim().ToUpper();
                var volcanoes = db.Volcanoes
                    .Include(p => p.Department)
                    .Include(p => p.City)
                    .Where(x => x.Name.ToUpper().Contains(search))
                    .ToList();
                return Results.Ok(volcanoes);
            })
            .Produces<List<Volcano>?>(200)
            .WithMetadata(new SwaggerOperationAttribute(
                summary: VolcanoMetadataMessages.MESSAGE_VOLCANO_BYNAME_SUMMARY,
                description: VolcanoMetadataMessages.MESSAGE_VOLCANO_BYNAME_DESCRIPTION
                ));

            group.MapGet("search/{keyword}", (string keyword, DBContext db) =>
            {
                string wellFormedKeyword = keyword.Trim().ToUpper().Normalize();
                var dbVolcanoes = db.Volcanoes.ToList();
                var volcanoes = Functions.FilterObjectListPropertiesByKeyword<Volcano>(dbVolcanoes, wellFormedKeyword);
                return Results.Ok(volcanoes);
            })
            .Produces<List<Volcano>>(200)
            .WithMetadata(new SwaggerOperationAttribute(
                summary: VolcanoMetadataMessages.MESSAGE_VOLCANO_SEARCH_SUMMARY,
                description: VolcanoMetadataMessages.MESSAGE_VOLCANO_SEARCH_DESCRIPTION
                ));

            group.MapGet("pagedList", async ([AsParameters] PaginationModel pagination, DBContext db) =>
            {
                if (pagination.Page <= 0 || pagination.PageSize <= 0)
                {
                    return Results.BadRequest();
                }

                var sortBy = pagination.SortBy ?? string.Empty;
                var sortDirectionStr = pagination.SortDirection?.ToString() ?? string.Empty;
                var queryVolcanoes = db.Volcanoes
                    .Include(p => p.Department)
                    .Include(p => p.City)
                    .AsQueryable();

                (queryVolcanoes, var isValidSort) = ApplySorting(queryVolcanoes, sortBy, sortDirectionStr);

                if (!isValidSort)
                {
                    return Results.BadRequest(RequestMessages.BadRequest);
                }

                var totalRecords = await queryVolcanoes.CountAsync();

                var pagedVolcanoes = await queryVolcanoes
                    .Skip((pagination.Page - 1) * pagination.PageSize)
                    .Take(pagination.PageSize)
                    .ToListAsync();

                var paginationResponse = new PaginationResponseModel<Volcano>
                {
                    Page = pagination.Page,
                    PageSize = pagination.PageSize,
                    TotalRecords = totalRecords,
                    Data = pagedVolcanoes
                };

                return Results.Ok(paginationResponse);
            })
            .Produces<PaginationResponseModel<Volcano>>(200)
            .WithMetadata(new SwaggerOperationAttribute(
                summary: VolcanoMetadataMessages.MESSAGE_VOLCANO_PAGEDLIST_SUMMARY,
                description: VolcanoMetadataMessages.MESSAGE_VOLCANO_PAGEDLIST_DESCRIPTION
                ));
        }
    }
}
