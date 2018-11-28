using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Services
{
    private readonly Guid _userId;

    public class FoodService(Guid userId)
    {
        _userId = userId;
    }
    
    
}
