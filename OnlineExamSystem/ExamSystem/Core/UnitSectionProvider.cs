using ExamSystem.Core.Services.DatabaseServices;
using ExamSystem.MVVM.Model.Question;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core
{
    public static class UnitSectionProvider
    {
        private static ReadOnlyDictionary<string, Unit> _unitMap;

        public static ReadOnlyDictionary<string, Unit> UnitMap
        {
            get
            {
                return _unitMap;
            }
            set
            {
                _unitMap = value;
            }
        }

        private static ReadOnlyDictionary<Unit, Dictionary<string, Section>> _sectionMap;

        public static ReadOnlyDictionary<Unit, Dictionary<string, Section>> SectionMap
        {
            get
            {
                return _sectionMap;
            }
            set
            {
                _sectionMap = value;
            }
        }
        
        public static async void InitializeMaps()
        {
            UnitService unitService = new UnitService();
            UnitMap  = await unitService.GetUnitDictionary();
            SectionService sectionService = new SectionService();
            SectionMap = await sectionService.GetSectionDictionary();
            
        }

    }
}
