// The Sharpener project and Facefire license this file to you under the MIT license.
using System.Text.Json;
using Sharpener.Json.Extensions;
using Sharpener.Json.Tests.Mocks;
using Sharpener.Json.Types;
using Sharpener.Tests.Common.Models;
public class SerializationExtensionsTests
{
    [Fact]
    public void WriteJson_Success()
    {
        var item = new Item("guy", "person");
        var asJson = item.WriteJson();
        var compareJson = JsonSerializer.Serialize(item, new JsonSerializerOptions { WriteIndented = true });
        asJson.Should().Be(compareJson);
    }
    [Fact]
    public void ReadJsonAs_Success()
    {
        var item = new Item("guy", "person");
        var asJson = item.WriteJson();
        var asItem = asJson.ReadJsonAs<Item>();
        asItem.Should().NotBeNull();
        asItem!.Name.Should().Be(item.Name);
    }
    [Fact]
    public void WriteJson_SetDefault_Success()
    {
        var item = new Item("guy", "person");
        SharpenerJsonSettings.SetDefaultWriter<JsonMockWriter>();
        item.WriteJson().Should().Be("stuff");
        SharpenerJsonSettings.ResetDefaults();
    }
    [Fact]
    public void WriteJson_UseType_Success()
    {
        var item = new Item("guy", "person");
        item.WriteJson<JsonMockWriter>().Should().Be("stuff");
    }
    [Fact]
    public void ReadJsonAs_SetDefault_Success()
    {
        var item = new Item("guy", "person");
        SharpenerJsonSettings.SetDefaultReader<JsonMockReader>();
        item.WriteJson().ReadJsonAs<Item>()!.Name.Should().Be("other");
        SharpenerJsonSettings.ResetDefaults();
    }
    [Fact]
    public void ReadJsonAs_UseType_Success()
    {
        var item = new Item("guy", "person");
        item.WriteJson().ReadJsonAs<Item, JsonMockReader>()!.Name.Should().Be("other");
    }
}
