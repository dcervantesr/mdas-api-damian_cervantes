# Challenge #1

### Run App Steps:

1. Start the container:

    `docker-compose up -d --force-recreate`

2. Make Requests:
   
    **2.1.** Api

    Do the following request through postman or your favorite browser: <br>
    `http://localhost:3080/api/v1/TypeGet/charizard` <br>
    
    Exception Scenarios: <br>
    1. Change the name `charizard` for any other pokemon you can imagine, and if not exists the app will throw an exception (***PokemonNotFoundException***) that indicates that the pokemon does not exist! <br><br>
    2. Test the Api without conection to internet to get the next controlled excepetion(***PokemonApiNotResponseException***) that indicates that the api is not responding!

    <br>

     **2.2.** Console

    Access to the console app within inside the container:<br>
    `docker exec -it pokemon /bin/sh`<br><br>
    Run the following command to execute the console app:<br>
    `dotnet PokemonConsole.dll`<br><br>
    Write the name of a pokemon and the app will return you the types of that peculiar pokemon.

3. ¡Enjoy our App!

### [Return to README](README.md)