-- UPDATE script: clean City descriptions
-- Issue: https://github.com/Mteheran/api-colombia/issues/194 (extended review of name/description data)
-- Removes leftover Wikipedia citation markers glued to the text (e.g. "Bogota.8", "Santa Marta,4",
-- "Santiago de Cali,8/9/10") and the invisible zero-width spaces (U+200B) that came with them.
-- Preserves legitimate typography: non-breaking spaces in measurements (e.g. "25.4 %", "17 °C", "115 km") are left intact,
-- and real figures are kept (e.g. Montelibano population stays "90.450", only the footnote "4" is removed).
-- Idempotent: UPDATE ... WHERE "Id" = N; re-running it is safe (the cleaned text no longer contains the markers).

BEGIN;

-- Medellín
UPDATE "City" SET "Description" = 'Medellín es un distrito colombiano, capital del departamento de Antioquia. Es la ciudad más poblada del departamento y la segunda más poblada del país después de Bogotá. Está ubicada en la parte más ancha de la región natural conocida como Valle de Aburrá, en la cordillera central de los Andes. Está extendida por ambas orillas del río Medellín, que la atraviesa de sur a norte, y es el municipio principal del Área metropolitana del Valle de Aburrá.' WHERE "Id" = 12;

-- Bogotá D.C.
UPDATE "City" SET "Description" = 'Bogotá, oficialmente Bogotá, Distrito Capital (antiguamente, Santafé de Bogotá y originalmente, Santafé), es la capital de la República de Colombia y del departamento de Cundinamarca. Está administrada como distrito capital, y goza de autonomía para la gestión de sus intereses dentro de los límites de la Constitución y la ley. A diferencia de los demás distritos de Colombia, Bogotá es una entidad territorial de primer orden, con las atribuciones administrativas que la ley confiere a los departamentos' WHERE "Id" = 167;

-- Cartagena
UPDATE "City" SET "Description" = 'Cartagena de Indias, oficialmente Distrito Turístico y Cultural de Cartagena de Indias (abreviado Cartagena de Indias, D. T. y C.), es la capital del departamento de Bolívar, al norte de Colombia. Fue fundada el 1 de junio de 1533 por Pedro de Heredia. Desde 1991 Cartagena es un Distrito Turístico y Cultural. La ciudad está ubicada a orillas del mar Caribe' WHERE "Id" = 210;

-- Florencia
UPDATE "City" SET "Description" = 'Florencia es un municipio colombiano, capital del departamento de Caquetá. Es el municipio más poblado de la región amazónica por su número de habitantes. Es conocido como «La Puerta de Oro de la Amazonía Colombiana»' WHERE "Id" = 364;

-- Yopal
UPDATE "City" SET "Description" = 'Yopal es un municipio colombiano, capital del departamento de Casanare. Su extensión territorial es de 2595 kilómetros cuadrados, y se sitúa a 317 kilómetros del distrito capital de Bogotá. Fundada por colonos boyacenses en 1915, es una de las capitales departamentales más jóvenes de Colombia y una de las ciudades que registra más rápido crecimiento poblacional a nivel nacional, en especial después de la separación de Casanare del departamento de Boyacá' WHERE "Id" = 380;

-- Valledupar
UPDATE "City" SET "Description" = 'Valledupar, también llamada Ciudad de los Santos Reyes del Valle de Upar, es un municipio colombiano, capital del departamento del Cesar. Es la cabecera del municipio homónimo, el cual tiene una extensión de 149 km², 559.462 habitantes y junto a su área metropolitana reúne 691.266 habitantes; está conformado por 25 corregimientos y 102 veredas.' WHERE "Id" = 441;

-- Montería
UPDATE "City" SET "Description" = 'Montería es un municipio colombiano, capital del departamento de Córdoba. Está ubicado al noroccidente del país en la región Caribe Colombiana, se encuentra a orillas del río Sinú, por lo que es conocida como la "Perla del Sinú". Es considerada la capital ganadera de Colombia; anualmente celebra la feria de la Ganadería durante el mes de junio. Es además, un importante centro comercial y universitario, reconocida como una de las ciudades colombianas con mayor crecimiento y desarrollo en los últimos años y por impulsar el desarrollo sostenible' WHERE "Id" = 498;

-- Montelíbano
UPDATE "City" SET "Description" = 'Montelíbano es un municipio del sur del departamento de Córdoba, Colombia. Situado sobre la margen derecha del río San Jorge y con una población de 90.450 habitantes aproximadamente, es en la actualidad uno de los centros de desarrollo económico, comercial y cultural más importantes de la región.' WHERE "Id" = 524;

-- Riohacha
UPDATE "City" SET "Description" = 'Riohacha, oficialmente Distrito Especial, Turístico y Cultural de Riohacha, (en wayuunaiki: Süchiimma que traduce a "Tierra del Río") es un distrito colombiano, capital del departamento de La Guajira. Se ubica en la costa del mar Caribe, en el delta del río Ranchería. Es el segundo municipio con mayor extensión territorial en su departamento y principal por constituir un vasto engranaje de entidades públicas, bancos y entidades financieras' WHERE "Id" = 694;

-- Santa Marta
UPDATE "City" SET "Description" = 'Santa Marta, oficialmente Distrito Turístico, Cultural e Histórico de Santa Marta, es la capital del departamento de Magdalena, Colombia. Fue fundada el 29 de julio de 1525 por el español Rodrigo de Bastidas, lo que según los textos, la hace la ciudad en pie más antigua de Colombia. Se encuentra a orillas de la bahía del mismo nombre.' WHERE "Id" = 709;

-- Villavicencio
UPDATE "City" SET "Description" = 'Villavicencio es un municipio colombiano, capital del departamento del Meta y el centro comercial más importante de los Llanos Orientales. Está ubicada en el piedemonte de la Cordillera Oriental, al noroccidente del departamento del Meta, en la margen derecha del río Guatiquía.' WHERE "Id" = 740;

-- Pasto
UPDATE "City" SET "Description" = 'Pasto es un municipio colombiano, capital del departamento de Nariño, cuya cabecera municipal ostenta el nombre de San Juan de Pasto. Se ubica en el suroccidente de la nación, en la región Andina.' WHERE "Id" = 769;

-- Puerto Asís
UPDATE "City" SET "Description" = 'Puerto Asís es un municipio colombiano localizado en el departamento del Putumayo. Conocido como la capital comercial del Putumayo por su predominio de las actividades del sector terciario o servicios en su economía que lo convierten el municipio con mayor peso relativo municipal en el valor agregado departamental (25.4 %). Es también el municipio con mayor población en el departamento' WHERE "Id" = 883;

-- Armenia
UPDATE "City" SET "Description" = 'Armenia es un municipio colombiano, capital del departamento del Quindío y núcleo económico de su área metropolitana. Es una de las principales ciudades del eje cafetero colombiano, la región paisa y el Paisaje Cultural Cafetero. Fundada en 1889 durante la colonización antioqueña, basó su economía en la agricultura' WHERE "Id" = 885;

-- Bucaramanga
UPDATE "City" SET "Description" = 'Bucaramanga es un municipio colombiano, capital del departamento de Santander. En 2015 un informe del Banco Mundial la situó como una de las urbes más competitivas y con mejor calidad de vida en América Latina. Está ubicada al nororiente del país sobre la Cordillera Oriental, rama de la cordillera de los Andes, a orillas del río de Oro.' WHERE "Id" = 915;

-- Cali
UPDATE "City" SET "Description" = 'Cali, oficialmente Distrito Especial, Deportivo, Cultural, Turístico, Empresarial y de Servicios de Santiago de Cali, es un distrito colombiano, capital del departamento de Valle del Cauca, la tercera ciudad más poblada y el tercer centro económico y cultural de Colombia. Está situada en la región Sur del Valle del Cauca.' WHERE "Id" = 1093;

-- Tuluá
UPDATE "City" SET "Description" = 'Tuluá es un municipio colombiano ubicado en la región central del departamento del Valle del Cauca. Es un motor comercial, demográfico, cultural, industrial, financiero y agropecuario del centro del departamento. Posee una cámara de comercio y es el cuarto municipio más poblado del Valle del Cauca' WHERE "Id" = 1111;

COMMIT;
