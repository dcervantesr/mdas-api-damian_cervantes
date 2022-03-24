## Hace todos los puntos pedidos (40%)

#### El nombre del repositorio es el correcto (mdas-web-${nombre}_${apellido})

OK

#### Permite obtener los detalles de un pokemon vía endpoint (datos + número de veces que se ha marcado como favorito)

OK, aunque ¿qué es counter?:

```
{
  "id": 3,
  "name": "venusaur",
  "height": 20,
  "weight": 1000,
  "counter": 0
}
```

Quizá `favorite_counter` o `times_marked_as_favorite` sería más claro

#### Actualiza el contador de favoritos vía eventos

OK

#### ¿Se controlan las excepciones de dominio? Y si se lanza una excepción desde el dominio, ¿se traduce en infraestructura a un código HTTP?

OK

#### Tests unitarios

- Falta lógica por testear. Ejemplo: `PokemonSaver`.

#### Tests de aceptación

- OK, aunque no se está testeando el flujo del subscriber.

#### Tests de integración

- No hay tests de integración del in memory.

**Puntuación: 28/40**

## Se aplican conceptos explicados (50%)

#### Separación correcta de capas (application, domain, infrastructure + BC/module/layer)

OK

#### Aggregates + VOs

OK

#### No se trabajan con tipos primitivos en dominio

OK

#### Hay servicios de dominio

- Tendría más sentido tener un servicio de dominio llamado `PokemonIncreaser` y delegar aquí la responsabilidad de
  obtener el pokemon, aumentar el número de pokemon favoritos y de guardar en el repositorio.

#### Hay use cases en aplicación reutilizables

- OK, aunque tendría más sentido que el caso de uso indicara que acción realiza: en vez de `PokemonAddAsFavoriteUseCase`
  sería mejor `IncreasePokemonFavoriteUseCase` o algo similar.

#### Se aplica el patrón repositorio

OK

#### Se usan subscribers

OK

#### Se lanzan eventos de dominio

OK

#### Se utilizan object mothers

OK

**Puntuación: 45/50**

## Facilidad setup + README (10%)

#### El README contiene al menos los apartados "cómo ejecutar la aplicación", "cómo usar la aplicación"

OK

#### Es sencillo seguir el apartado "cómo ejecutar la aplicación"

- Aunque faltan el user y password en el paso `Load RabbitMq site`.
- ¿Cómo ejecuto los tests?

**Puntuación: 7/10**

**PUNTUACIÓN FINAL: 80/100**
