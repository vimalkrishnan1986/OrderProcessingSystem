using System.Collections.Generic;

namespace OrderProcessingSystem.Common.Components
{
    public interface IComponentSupplier
    {
        IEnumerable<IComponent> GetComponents();
    }
}
