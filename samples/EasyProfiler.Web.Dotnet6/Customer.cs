namespace EasyProfiler.Web.Dotnet6
{
    /// <summary>
    /// Customer Entity
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// PK of Customer entity
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Name of Customer
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Surname of Customer
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Creation Time for Customer Entity
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
