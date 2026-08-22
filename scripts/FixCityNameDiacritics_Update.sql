-- UPDATE script: fix diacritics/typos in City names
-- Issue: https://github.com/Mteheran/api-colombia/issues/194
-- Corrects missing/incorrect accent marks (tildes, dieresis) on Colombian municipality names.
-- Names validated against the official DANE municipality list (marcovega/colombia-json) and
-- cross-checked on Wikipedia for the cases that remove/relocate an existing accent (ids 127, 865, 957).
-- Idempotent: uses UPDATE ... WHERE "Id" = N, so it can be re-run safely (no INSERT, no duplicate-key errors).
-- Scope: names only; every affected city has an empty Description, so no description changes are needed.

BEGIN;

UPDATE "City" SET "Name" = 'Anzá' WHERE "Id" = 22;  -- was 'Anza'
UPDATE "City" SET "Name" = 'Entrerríos' WHERE "Id" = 54;  -- was 'Entrerrios'
UPDATE "City" SET "Name" = 'Itagüí' WHERE "Id" = 65;  -- was 'Itagui'
UPDATE "City" SET "Name" = 'San Pedro de Urabá' WHERE "Id" = 124;  -- was 'San Pedro de Uraba'
UPDATE "City" SET "Name" = 'San Andrés de Cuerquia' WHERE "Id" = 127;  -- was 'San Andrés de Cuerquía'
UPDATE "City" SET "Name" = 'Suán' WHERE "Id" = 158;  -- was 'Suan'
UPDATE "City" SET "Name" = 'Gámeza' WHERE "Id" = 252;  -- was 'Gameza'
UPDATE "City" SET "Name" = 'Úmbita' WHERE "Id" = 321;  -- was 'Umbita'
UPDATE "City" SET "Name" = 'Belén de Los Andaquíes' WHERE "Id" = 375;  -- was 'Belén de Los Andaquies'
UPDATE "City" SET "Name" = 'Guapí' WHERE "Id" = 412;  -- was 'Guapi'
UPDATE "City" SET "Name" = 'Sotará' WHERE "Id" = 430;  -- was 'Sotara'
UPDATE "City" SET "Name" = 'Toribío' WHERE "Id" = 435;  -- was 'Toribio'
UPDATE "City" SET "Name" = 'Alto Baudó' WHERE "Id" = 469;  -- was 'Alto Baudo'
UPDATE "City" SET "Name" = 'Bojayá' WHERE "Id" = 474;  -- was 'Bojaya'
UPDATE "City" SET "Name" = 'Río Iró' WHERE "Id" = 484;  -- was 'Río Iro'
UPDATE "City" SET "Name" = 'Cáqueza' WHERE "Id" = 536;  -- was 'Caqueza'
UPDATE "City" SET "Name" = 'Fómeque' WHERE "Id" = 546;  -- was 'Fomeque'
UPDATE "City" SET "Name" = 'Gachalá' WHERE "Id" = 550;  -- was 'Gachala'
UPDATE "City" SET "Name" = 'Machetá' WHERE "Id" = 570;  -- was 'Macheta'
UPDATE "City" SET "Name" = 'Guayabal de Síquima' WHERE "Id" = 627;  -- was 'Guayabal de Siquima'
UPDATE "City" SET "Name" = 'Íquira' WHERE "Id" = 671;  -- was 'Iquira'
UPDATE "City" SET "Name" = 'El Piñón' WHERE "Id" = 717;  -- was 'El Piñon'
UPDATE "City" SET "Name" = 'Sabanas de San Ángel' WHERE "Id" = 734;  -- was 'Sabanas de San Angel'
UPDATE "City" SET "Name" = 'Acacías' WHERE "Id" = 741;  -- was 'Acacias'
UPDATE "City" SET "Name" = 'Consacá' WHERE "Id" = 775;  -- was 'Consaca'
UPDATE "City" SET "Name" = 'Ábrego' WHERE "Id" = 859;  -- was 'Abrego'
UPDATE "City" SET "Name" = 'Cáchira' WHERE "Id" = 865;  -- was 'Cachirá'
UPDATE "City" SET "Name" = 'Duranía' WHERE "Id" = 867;  -- was 'Durania'
UPDATE "City" SET "Name" = 'Gámbita' WHERE "Id" = 945;  -- was 'Gambita'
UPDATE "City" SET "Name" = 'Lebrija' WHERE "Id" = 957;  -- was 'Lebríja'
UPDATE "City" SET "Name" = 'Colosó' WHERE "Id" = 1003;  -- was 'Coloso'
UPDATE "City" SET "Name" = 'Falán' WHERE "Id" = 1038;  -- was 'Falan'
UPDATE "City" SET "Name" = 'Carmen de Apicalá' WHERE "Id" = 1064;  -- was 'Carmen de Apicala'

COMMIT;
