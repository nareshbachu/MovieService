# Movies Service

**Solution consists of the following projects:**
- Service 
- Contract
- Unit test

**About the solution:**
The main intention of the project is to provide APIs for users to be able to search and rate movies. Please find the endpoints documentation on swagger when you launch the application.

**Data:** 
When the application is launched, it creates and seeds 20 movies and 5 users. It also adds ratings by picking a random user and a movie. 
Users are created with the following user ids:
- 88116f04-ee0a-40aa-90ca-b54ef5eea075
- c3406ecd-cf96-46b5-a61f-a98ce6b24637
- df6056d0-d0c3-4526-9976-ef9e47e97c0c
- f3b8f0ba-8476-43db-8814-a95af30cebb9
- b5c80665-d77d-48df-8847-55246fa54f71

Movies are created with titles 'Movie 1', 'Movie 2'.....'Movie 20'. Each movie is randomly assigned with one or more of the following genres.
- Comedy
- Action
- Thriller
- Drama
- fiction

Please use this data to search movies and add ratings.

**Enhancements:**
For this application I have used inmemory database provided by .Net core but as this is a search heavy application it would be better to use a good document database like Elastic search and if necessary use cache on top of it.

Also, given more time I would like to write more unit tests as well as some functionality tests. 




