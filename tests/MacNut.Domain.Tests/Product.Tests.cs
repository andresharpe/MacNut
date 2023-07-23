using FluentAssertions;
using FluentAssertions.Execution;
using MacNut.Types;
using System.Collections.Immutable;
using System.Net;

namespace MacNut.Domain.Tests;

public class ProductTests
{
    [Fact]
    public void Construct_Product_Returns_Valid_Product()
    {

        var categories = new List<Category>() {
            new Category("en:canned-black-beans"),
            new Category("en:canned-common-beans"),
            new Category("en:black-beans"),
        };

        var product = new Product
        (
            id: ProductCode.From("5601151170755"),
            name: Text.From("Haricots noirs"),
            manufacturer: Text.From("Compal"),
            weight: Weight.From(234, WeightUnit.Grams),
            energy: Energy.From(75, EnergyUnit.KCal),
            fats: WeightPortion.From(0.5, WeightPortionUnit.Per100Gram),
            saturatedFats: WeightPortion.From(0.1, WeightPortionUnit.Per100Gram),
            carbs: WeightPortion.From(9.0, WeightPortionUnit.Per100Gram),
            sugars: WeightPortion.From(0.5, WeightPortionUnit.Per100Gram),
            fibres: WeightPortion.From(5.5, WeightPortionUnit.Per100Gram),
            proteins: WeightPortion.From(5.8, WeightPortionUnit.Per100Gram),
            salts: WeightPortion.From(1.06, WeightPortionUnit.Per100Gram),
            categories: categories
        ) ;

        product.Id.Value.Should().Be("5601151170755");

        product.Energy.ToKiloJoules().Should().BeApproximately(314f, 1f);

        product.Energy.ToString().Should().Be("75 KCal");
    }

}