using System.Collections.Generic;
using NzbDrone.Core.Annotations;

namespace NzbDrone.Core.Indexers
{
    public class IndexerFlagFieldConverter : ISelectOptionsConverter
    {
        public static readonly IReadOnlyDictionary<int, IndexerFlag> Map = new Dictionary<int, IndexerFlag>
        {
            { 1, IndexerFlag.FreeLeech },
            { 2, IndexerFlag.HalfLeech },
            { 3, IndexerFlag.NeutralLeech },
            { 4, IndexerFlag.DoubleUpload },
            { 5, IndexerFlag.Internal },
            { 6, IndexerFlag.Exclusive },
            { 7, IndexerFlag.Scene }
        };

        public List<SelectOption> GetSelectOptions()
        {
            var result = new List<SelectOption>();
            var order = 0;

            foreach (var entry in Map)
            {
                result.Add(new SelectOption
                {
                    Value = entry.Key,
                    Name = entry.Value.Name,
                    Hint = entry.Value.Description,
                    Order = order++
                });
            }

            return result;
        }
    }
}
