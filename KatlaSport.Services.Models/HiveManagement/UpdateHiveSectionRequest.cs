namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents HiveSectionRequest either it is added/updated.
    /// </summary>
    public class UpdateHiveSectionRequest
    {
        /// <summary>
        /// Name of a <see cref="HiveSection"/>
        /// </summary>
        public string Name;

        /// <summary>
        /// Code of a section
        /// </summary>
        public string Code;

        /// <summary>
        /// Id of <see cref="Hive"/>
        /// </summary>
        public int Id;
    }
}