using System.Threading.Tasks;

namespace OrderProcessingSystem.Common.Components
{
    public interface IComponent
    {
        /// <summary>
        /// It will decide what needs to be  like sending email
        /// </summary>
        Task Process();
    }
}
