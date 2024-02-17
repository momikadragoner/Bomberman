using Bomberman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BomberMan.Persistence
{
    public class TwoDimEnumArrayJsonConverter : JsonConverter<TileEnum[,]>
    {
        public override TileEnum[,]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);

            var rowLength = doc.RootElement.GetArrayLength();
            var columnLength = doc.RootElement.EnumerateArray().First().GetArrayLength();

            TileEnum[,] grid = new TileEnum[rowLength, columnLength];

            int row = 0;
            foreach (var array in doc.RootElement.EnumerateArray())
            {
                int column = 0;
                foreach (var number in array.EnumerateArray())
                {
                    grid[row, column] = (TileEnum)number.GetInt32();
                    column++;
                }
                row++;
            }

            return grid;
        }

        public override void Write(Utf8JsonWriter writer, TileEnum[,] value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            for (int i = 0; i < value.GetLength(0); i++)
            {
                writer.WriteStartArray();
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    writer.WriteNumberValue((int)value[i, j]);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
        }
    }
}
