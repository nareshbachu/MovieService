namespace MoviesService.Contract
{
    public class User
    {
        /// <summary>
        /// Identifier for the user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Full name of the user
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email of the user also used for login
        /// </summary>
        public string Email { get; set; }
    }
}