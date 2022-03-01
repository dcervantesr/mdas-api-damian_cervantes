# Individual Challenge

### Run App Steps:

1. Start the container:

    `docker-compose -f docker-compose-RetoInd.yml  up -d --force-recreate`

2. In Docker Desktop restart the PokemonApi container.
- This happens because the container lifts and the configuration of the rabbit is not yet ready.

3. Load RabbitMq site http://localhost:15672/#/

4. Load PokemonApi Swagger site http://localhost:3080/swagger/index.html

5. Load UserApi Swagger site http://localhost:4080/swagger/index.html

6. In UserApi create a new user and then add a favorite user to the created user.

* User 1
``` json
{
  "name": "Pepe",
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa8"
}
```
* User 2
``` json
{
  "name": "Maria",
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa9"
}
```

* Add favorite: Pokemon 1 User Pepe 
```json
{
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
  "pokemonId": 1
}
```

* Add favorite: Pokemon 2 User Pepe 
```json
{
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
  "pokemonId": 2
}
```

* Add favorite: Pokemon 1 User Maria 
```json
{
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa9",
  "pokemonId": 1
}
```

7. In PokemonApi get the pokemon with the pokemon id added as favorite.
* Get Pokemon with id 1 -> favoriteCounter = 2
* Get Pokemon with id 2 -> favoriteCounter = 1