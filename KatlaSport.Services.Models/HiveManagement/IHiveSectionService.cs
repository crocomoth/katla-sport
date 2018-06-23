using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a hive section service.
    /// </summary>
    public interface IHiveSectionService
    {
        /// <summary>
        /// Gets a list of hive sections.
        /// </summary>
        /// <returns>A <see cref="Task{List{HiveSectionListItem}}"/>.</returns>
        Task<List<HiveSectionListItem>> GetHiveSectionsAsync();

        /// <summary>
        /// Gets a hive section.
        /// </summary>
        /// <param name="id">A hive section identifier.</param>
        /// <returns>A <see cref="Task{HiveSection}"/>.</returns>
        Task<HiveSection> GetHiveSectionAsync(int id);

        /// <summary>
        /// Gets a list of hive sections for specified hive.
        /// </summary>
        /// <param name="hiveId">A hive identifier.</param>
        /// <returns>A <see cref="Task{List{HiveSectionListItem}}"/>.</returns>
        Task<List<HiveSectionListItem>> GetHiveSectionsAsync(int hiveId);

        /// <summary>
        /// Sets deleted status for a hive section.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <param name="deletedStatus">Status.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task SetStatusAsync(int hiveSectionId, bool deletedStatus);

        /// <summary>
        /// Creates a new <see cref="HiveSection"/> asynchronously.
        /// </summary>
        /// <param name="request">Request which is send by user.</param>
        /// <returns>New HiveSevtion.</returns>
        Task<HiveSection> CreateHiveSectionAsync(UpdateHiveSectionRequest request);

        /// <summary>
        /// Updates an existing <see cref="HiveSection"/> asynchronously.
        /// </summary>
        /// <param name="id">Id of a HiveSection.</param>
        /// <param name="updateRequest">Request sended by user.</param>
        /// <returns>Updated HiveSection.</returns>
        Task<HiveSection> UpdateHiveSectionAsync(int id, UpdateHiveSectionRequest updateRequest);

        /// <summary>
        /// Deleted an existing <see cref="HiveSection"/> asynchronously.
        /// </summary>
        /// <param name="id">Id of HiveSection to be deleted.</param>
        /// <returns><see cref="Task"/></returns>
        Task DeleteHiveSectionAsync(int id);
    }
}
