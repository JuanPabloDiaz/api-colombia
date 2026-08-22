-- UPDATE script: fix typos and grammar in InvasiveSpecie text fields
-- Issue: https://github.com/Mteheran/invasivespecie-colombia/issues/16
-- The issue reported one typo (id 45: "serie amenaza" -> "seria amenaza"); a full review of
-- all 72 records surfaced additional spelling/grammar errors, corrected below.
-- Idempotent: each fix is a scoped REPLACE(...) WHERE "Id" = N, so re-running is a no-op
-- once the original substring is gone (no INSERT, no duplicate-key risk).
-- Scope: clear orthographic/grammatical errors only; scientific names left as-is except
--   unambiguous ones (Aphanomyces astaci, L. camara, H. helix, H. frenatus casing).

BEGIN;

-- id 2 — Alfombra de agua (Azolla filiculoides Lam)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'a la perdida de superficies', 'a la pérdida de superficies') WHERE "Id" = 2;
  -- "a la perdida de superficies" -> "a la pérdida de superficies"

-- id 5 — Bambú de la India (Bambusa vulgaris Schrad.)
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE("Manage", 'tala continúa', 'tala continua') WHERE "Id" = 5;
  -- "tala continúa" -> "tala continua"

-- id 8 — Buchón (Limnobium laevigatum (Humb. & Bonpl. ex Willd.) Heine)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'nativas y perdida de espacios', 'nativas y pérdida de espacios') WHERE "Id" = 8;
  -- "nativas y perdida de espacios" -> "nativas y pérdida de espacios"

-- id 11 — Caña brava (Arundo donax L)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'causa perdida de biodiversidad', 'causa pérdida de biodiversidad') WHERE "Id" = 11;
  -- "causa perdida de biodiversidad" -> "causa pérdida de biodiversidad"

-- id 12 — Caracucho (Impatiens balsamina L.)
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE("Manage", 'el hongos Podosphaera', 'los hongos Podosphaera') WHERE "Id" = 12;
  -- "el hongos Podosphaera" -> "los hongos Podosphaera"

-- id 15 — Diente de león (Taraxacum campylodes G.E. Haglund)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'áreas antropisadas', 'áreas antropizadas') WHERE "Id" = 15;
  -- "áreas antropisadas" -> "áreas antropizadas"

-- id 16 — Elodea (Egeria densa Planch.)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'oxígeno he impide', 'oxígeno e impide') WHERE "Id" = 16;
  -- "oxígeno he impide" -> "oxígeno e impide"

-- id 17 — Enea, junco (Typha angustifolia L)
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE(REPLACE("Manage", 'los herbisidas convencionales', 'los herbicidas convencionales'), 'la planta se encuenta en floración', 'la planta se encuentra en floración') WHERE "Id" = 17;
  -- "los herbisidas convencionales" -> "los herbicidas convencionales"
  -- "la planta se encuenta en floración" -> "la planta se encuentra en floración"

-- id 18 — Eucalipto (Eucalyptus camaldulensis Dehnh)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE(REPLACE("Impact", 'este árbol agotan los nutrientes', 'este árbol agota los nutrientes'), 'que impide el crecimiento de otras especies', 'que impiden el crecimiento de otras especies') WHERE "Id" = 18;
  -- "este árbol agotan los nutrientes" -> "este árbol agota los nutrientes"
  -- "que impide el crecimiento de otras especies" -> "que impiden el crecimiento de otras especies"

-- id 28 — Lechuga de agua (Pistia stratiotes L.)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'provaca cambios', 'provoca cambios') WHERE "Id" = 28;
  -- "provaca cambios" -> "provoca cambios"
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE("Manage", 'El control quimico puede generar', 'El control químico puede generar') WHERE "Id" = 28;
  -- "El control quimico puede generar" -> "El control químico puede generar"

-- id 29 — Lengüevaca (Rumex crispus L.)
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE(REPLACE(REPLACE(REPLACE("Manage", 'En Autralia se ha realizado', 'En Australia se ha realizado'), 'los hongo Uromyces rumicis', 'los hongos Uromyces rumicis'), 'R. crispuscomo, reportando', 'R. crispus, reportando'), 'En Republica Checa', 'En República Checa') WHERE "Id" = 29;
  -- "En Autralia se ha realizado" -> "En Australia se ha realizado"
  -- "los hongo Uromyces rumicis" -> "los hongos Uromyces rumicis"
  -- "R. crispuscomo, reportando" -> "R. crispus, reportando"
  -- "En Republica Checa" -> "En República Checa"

-- id 30 — Lenteja de agua (Lemna aequinoctialis Welw)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'nativas y perdida de espacios', 'nativas y pérdida de espacios') WHERE "Id" = 30;
  -- "nativas y perdida de espacios" -> "nativas y pérdida de espacios"

-- id 32 — Llantén (Plantago major L)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE(REPLACE("Impact", 'en el Reuno Unido', 'en el Reino Unido'), 'en Canadá esta presenta en 80%', 'en Canadá está presente en 80%') WHERE "Id" = 32;
  -- "en el Reuno Unido" -> "en el Reino Unido"
  -- "en Canadá esta presenta en 80%" -> "en Canadá está presente en 80%"
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE("Manage", 'usar los herbicida 2,4-D', 'usar los herbicidas 2,4-D') WHERE "Id" = 32;
  -- "usar los herbicida 2,4-D" -> "usar los herbicidas 2,4-D"

-- id 34 — Panelo (Leucaena leucocephala)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'altera el ciclare de nutrientes', 'altera el ciclo de nutrientes') WHERE "Id" = 34;
  -- "altera el ciclare de nutrientes" -> "altera el ciclo de nutrientes"
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE(REPLACE("Manage", 'En sur África se ha probado', 'En Sudáfrica se ha probado'), 'ponen sus huevos en la vainas vacías', 'ponen sus huevos en las vainas vacías') WHERE "Id" = 34;
  -- "En sur África se ha probado" -> "En Sudáfrica se ha probado"
  -- "ponen sus huevos en la vainas vacías" -> "ponen sus huevos en las vainas vacías"

-- id 45 — Susanita (Thunbergia alata)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'convirtiéndose en una serie amenaza', 'convirtiéndose en una seria amenaza') WHERE "Id" = 45;
  -- "convirtiéndose en una serie amenaza" -> "convirtiéndose en una seria amenaza"
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE("Manage", 'las raíces subterráneas tiene que ser eliminadas', 'las raíces subterráneas tienen que ser eliminadas') WHERE "Id" = 45;
  -- "las raíces subterráneas tiene que ser eliminadas" -> "las raíces subterráneas tienen que ser eliminadas"

-- id 47 — Venturosa (Lantana camara L)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'L. cámara proporcionan criaderos a la moscas', 'L. camara proporciona criaderos a las moscas') WHERE "Id" = 47;
  -- "L. cámara proporcionan criaderos a la moscas" -> "L. camara proporciona criaderos a las moscas"
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE("Manage", 'invasiones de L. cámara', 'invasiones de L. camara') WHERE "Id" = 47;
  -- "invasiones de L. cámara" -> "invasiones de L. camara"

-- id 48 — Verbena blanca (Verbena litoralis Kunth)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'causando perdidas económicas', 'causando pérdidas económicas') WHERE "Id" = 48;
  -- "causando perdidas económicas" -> "causando pérdidas económicas"

-- id 50 — Yedra (Hedera helix L.)
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE(REPLACE("Manage", 'H. hélice', 'H. helix'), 'aplicar el un herbicidas sin diluir', 'aplicar el herbicida sin diluir') WHERE "Id" = 50;
  -- "H. hélice" -> "H. helix"
  -- "aplicar el un herbicidas sin diluir" -> "aplicar el herbicida sin diluir"

-- id 52 — Carpa Común (Cyprinus carpio)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'y aumentar la turbidez de las aguas', 'y aumenta la turbidez de las aguas') WHERE "Id" = 52;
  -- "y aumentar la turbidez de las aguas" -> "y aumenta la turbidez de las aguas"
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE("Manage", 'debido a venenos específicos para la carpa común no están disponibles', 'debido a que venenos específicos para la carpa común no están disponibles') WHERE "Id" = 52;
  -- "debido a venenos específicos para la carpa común no están disponibles" -> "debido a que venenos específicos para la carpa común no están disponibles"

-- id 53 — Cangrejo rojo americano (Procambarus clarkii)
UPDATE "InvasiveSpecie" SET "CommonNames" = REPLACE("CommonNames", 'cangrejo rojo de Louissiana', 'cangrejo rojo de Louisiana') WHERE "Id" = 53;
  -- "cangrejo rojo de Louissiana" -> "cangrejo rojo de Louisiana"
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE(REPLACE("Impact", 'esta especie ocaciona varios impactos', 'esta especie ocasiona varios impactos'), 'hongo Aphanomycetes astaci', 'hongo Aphanomyces astaci') WHERE "Id" = 53;
  -- "esta especie ocaciona varios impactos" -> "esta especie ocasiona varios impactos"
  -- "hongo Aphanomycetes astaci" -> "hongo Aphanomyces astaci"

-- id 59 — Geko casero (Hemidactylus frenatus)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE(REPLACE("Impact", 'que H. Frenatus desplaza', 'que H. frenatus desplaza'), 'responsable de disminuir poblacional de los gekos', 'responsable de la disminución poblacional de los gekos') WHERE "Id" = 59;
  -- "que H. Frenatus desplaza" -> "que H. frenatus desplaza"
  -- "responsable de disminuir poblacional de los gekos" -> "responsable de la disminución poblacional de los gekos"

-- id 61 — Paloma doméstica (Columba livia)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'ha causado perdidas hasta', 'ha causado pérdidas hasta') WHERE "Id" = 61;
  -- "ha causado perdidas hasta" -> "ha causado pérdidas hasta"

-- id 62 — Pato de collar (Anas platyrhynchos)
UPDATE "InvasiveSpecie" SET "CommonNames" = REPLACE("CommonNames", 'anade rea', 'ánade real') WHERE "Id" = 62;
  -- "anade rea" -> "ánade real"
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE(REPLACE(REPLACE("Impact", 'A. platyrhynchos cuasa efectos', 'A. platyrhynchos causa efectos'), 'híbridos del esta especie', 'híbridos de esta especie'), 'grandes población silvestre de este pato están', 'grandes poblaciones silvestres de este pato están') WHERE "Id" = 62;
  -- "A. platyrhynchos cuasa efectos" -> "A. platyrhynchos causa efectos"
  -- "híbridos del esta especie" -> "híbridos de esta especie"
  -- "grandes población silvestre de este pato están" -> "grandes poblaciones silvestres de este pato están"

-- id 63 — Perro doméstico (Canis lupus)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'con transmisores la pérdida 13 individuos fueron depredados', 'con transmisores 13 individuos fueron depredados') WHERE "Id" = 63;
  -- "con transmisores la pérdida 13 individuos fueron depredados" -> "con transmisores 13 individuos fueron depredados"

-- id 64 — Rana toro (Lithobates catesbeianus)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE(REPLACE("Impact", 'que es responsables de la disminución', 'que es responsable de la disminución'), 'extinción de otras población de anfibios', 'extinción de otras poblaciones de anfibios') WHERE "Id" = 64;
  -- "que es responsables de la disminución" -> "que es responsable de la disminución"
  -- "extinción de otras población de anfibios" -> "extinción de otras poblaciones de anfibios"

-- id 65 — Rata casera (Rattus rattus)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'considerada un plaaga responsable', 'considerada una plaga responsable') WHERE "Id" = 65;
  -- "considerada un plaaga responsable" -> "considerada una plaga responsable"

-- id 66 — Rata noruega (Rattus norvegicus)
UPDATE "InvasiveSpecie" SET "CommonNames" = REPLACE("CommonNames", 'rata cafè', 'rata café') WHERE "Id" = 66;
  -- "rata cafè" -> "rata café"
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE("Impact", 'plaga bubónica, tifoidea', 'peste bubónica, tifoidea') WHERE "Id" = 66;
  -- "plaga bubónica, tifoidea" -> "peste bubónica, tifoidea"
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE("Manage", 'Brodifacoum fue le mas usado', 'Brodifacoum fue el más usado') WHERE "Id" = 66;
  -- "Brodifacoum fue le mas usado" -> "Brodifacoum fue el más usado"

-- id 67 — Ratón casero (Mus musculus)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE(REPLACE("Impact", 'alimentos para los humano, además', 'alimentos para los humanos, además'), 'además y son huesped de una serie', 'además son huésped de una serie') WHERE "Id" = 67;
  -- "alimentos para los humano, además" -> "alimentos para los humanos, además"
  -- "además y son huesped de una serie" -> "además son huésped de una serie"

-- id 68 — Tilapia del nilo (Oreochromis niloticus)
UPDATE "InvasiveSpecie" SET "Impact" = REPLACE(REPLACE("Impact", 'poblaciones muy grandes que beneficia a los pescadores', 'poblaciones muy grandes que benefician a los pescadores'), 'pueden generar efecto negativos', 'pueden generar efectos negativos') WHERE "Id" = 68;
  -- "poblaciones muy grandes que beneficia a los pescadores" -> "poblaciones muy grandes que benefician a los pescadores"
  -- "pueden generar efecto negativos" -> "pueden generar efectos negativos"
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE("Manage", 'podría controlarla esta especie', 'podría controlar esta especie') WHERE "Id" = 68;
  -- "podría controlarla esta especie" -> "podría controlar esta especie"

-- id 69 — Trucha arcoíris (Oncorhynchus mykiss)
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE("Manage", 'esta comenzando a causar impactos', 'está comenzando a causar impactos') WHERE "Id" = 69;
  -- "esta comenzando a causar impactos" -> "está comenzando a causar impactos"

-- id 72 — Pez León (Pterois antennata)
UPDATE "InvasiveSpecie" SET "Manage" = REPLACE("Manage", 'para la extración y eliminación', 'para la extracción y eliminación') WHERE "Id" = 72;
  -- "para la extración y eliminación" -> "para la extracción y eliminación"

COMMIT;
