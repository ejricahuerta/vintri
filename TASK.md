# vintri



Exercise: Create a C# Asp.Net Web API project and implement the following 4 tasks
The following resource should be referenced to complete the exercise.
Punk API documentation: https://punkapi.com/documentation/v2

Task 1: Add a REST API endpoint to allow a user to add a rating to a beer.

This endpoint should accept an id parameter and JSON request body which includes the following properties: username, rating, comments.
Add validation to ensure the id parameter is a valid beer id by querying the Punk API.
Add validation to ensure that the rating is a valid value in the range of 1 to 5.
If any of the validations fail an applicable error should be returned to the user.
All valid requests should append the JSON from the request body to a file called database.json stored within a solution folder of your choosing.

Task 2: Add a REST API endpoint to retrieve a list of beers.

This endpoint should accept one parameter in the query string of the request. The purpose of this parameter is to denote the name of the beer to search for.
The implementation of your REST endpoint will use the public available Punk API to retrieve all beers matching the search parameter described above.
After retrieving the search result, load the contents of the database.json file into an in-memory collection and write a Linq query to project an API response that follows the structure of the following example:
[
{
&#34;id&#34;:&#34;1&#34;,
&#34;name&#34;:&#34;Buzz&#34;,
&#34;description&#34;:&#34;A light, crisp and bitter IPA brewed with English and American hops. A small batch brewed only once.&#34;,
&#34;userRatings&#34;:[
{
&#34;username&#34;:&#34;john.doe&#64;fictitious.com&#34;,
&#34;rating&#34;:3,
&#34;comments&#34;:&#34;Lorem ipsum dolor sit amet, consectetur adipiscing elit&#34;
},
{
&#34;username&#34;:&#34;max.power&#64;fictitious.com&#34;,
&#34;rating&#34;:5,
&#34;comments&#34;:&#34;sed do eiusmod tempor incididunt ut labore&#34;
}
]
}
]

Task 3: Add a custom Web API Action Filter Attribute

This action filter attribute is for the purpose of validating the username supplied in the JSON body of the REST operation described in task 1. The validation should use a regular expression to ensure the username value is a valid formatted email address. If the username is not valid an applicable error should be returned by the API.

Task 4: Add unit tests

Add applicable Unit tests to a routine of your choosing that formed part of the implementation of one of the above tasks.
