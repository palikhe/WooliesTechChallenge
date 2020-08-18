using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesTechChallenge.Service.Domain;
using WooliesTechChallenge.Service.Infrastructure;
using WooliesTechChallenge.Service.Interface;
using Xunit;

namespace WooliesTechChallenge.Service.Tests
{
    public class ProductSorterTests
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public async Task ProductSorter_Should_Correctly_Sort_Product_Based_On_Popularity(PopularitySortTestData testData)
        {
            var apiCaller = new Mock<IApiCaller>();
            apiCaller.Setup(x => x.GetProducts()).ReturnsAsync(testData.AllProducts);
            apiCaller.Setup(x => x.GetShopperHistory()).ReturnsAsync(testData.ShopperHistoryReponse);

            var sut = new ProductSorter(apiCaller.Object);

            var result = await sut.SortProducts(SortOptions.Recommended.ToString());

            Assert.Equal(testData.ExpectedResult.Select(x => x.Name), result.Select(x => x.Name));

        }

        public static IEnumerable<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new PopularitySortTestData()
                    {
                        AllProducts = new List<ProductWithQuantity>()
                        {
                            new ProductWithQuantity()
                            {
                                Name = "Product A",
                                Price = 10.0m,
                                Quantity = 0
                            },
                            new ProductWithQuantity()
                            {
                                Name = "Product B",
                                Price = 10.0m,
                                Quantity = 0
                            },
                            new ProductWithQuantity()
                            {
                                Name = "Product C",
                                Price = 10.0m,
                                Quantity = 0
                            }
                        },

                        ShopperHistoryReponse = new List<ShopperHistoryReponse>()
                        {
                            new ShopperHistoryReponse()
                            {
                                CustomerId = 2,
                                Products = new List<ProductWithQuantity>()
                                {
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product A",
                                        Price = 10.0m,
                                        Quantity = 0
                                    },
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product B",
                                        Price = 10.0m,
                                        Quantity = 0
                                    },
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product C",
                                        Price = 10.0m,
                                        Quantity = 0
                                    }
                                }
                            },
                            new ShopperHistoryReponse()
                            {
                                CustomerId = 3,
                                Products = new List<ProductWithQuantity>()
                                {
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product A",
                                        Price = 10.0m,
                                        Quantity = 0
                                    },
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product B",
                                        Price = 10.0m,
                                        Quantity = 0
                                    }
                                }
                            },
                            new ShopperHistoryReponse()
                            {
                                CustomerId = 4,
                                Products = new List<ProductWithQuantity>()
                                {
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product B",
                                        Price = 10.0m,
                                        Quantity = 0
                                    }
                                }
                            }
                        },

                        ExpectedResult = new List<ProductWithQuantity>()
                        {
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product B",
                                        Price = 10.0m,
                                        Quantity = 0
                                    },
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product A",
                                        Price = 10.0m,
                                        Quantity = 0
                                    },
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product C",
                                        Price = 10.0m,
                                        Quantity = 0
                                    }
                        }

                    }
                },
                new object[]
                {
                    new PopularitySortTestData()
                    {
                        AllProducts = new List<ProductWithQuantity>()
                        {
                            new ProductWithQuantity()
                            {
                                Name = "Product A",
                                Price = 10.0m,
                                Quantity = 0
                            },
                            new ProductWithQuantity()
                            {
                                Name = "Product B",
                                Price = 10.0m,
                                Quantity = 0
                            },
                            new ProductWithQuantity()
                            {
                                Name = "Product C",
                                Price = 10.0m,
                                Quantity = 0
                            },
                            new ProductWithQuantity()
                            {
                                Name = "Product D",
                                Price = 10.0m,
                                Quantity = 0
                            }
                        },

                        ShopperHistoryReponse = new List<ShopperHistoryReponse>()
                        {
                            new ShopperHistoryReponse()
                            {
                                CustomerId = 2,
                                Products = new List<ProductWithQuantity>()
                                {
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product A",
                                        Price = 10.0m,
                                        Quantity = 0
                                    },
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product B",
                                        Price = 10.0m,
                                        Quantity = 0
                                    },
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product C",
                                        Price = 10.0m,
                                        Quantity = 0
                                    }
                                }
                            },
                            new ShopperHistoryReponse()
                            {
                                CustomerId = 3,
                                Products = new List<ProductWithQuantity>()
                                {
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product A",
                                        Price = 10.0m,
                                        Quantity = 0
                                    },
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product B",
                                        Price = 10.0m,
                                        Quantity = 0
                                    }
                                }
                            },
                            new ShopperHistoryReponse()
                            {
                                CustomerId = 4,
                                Products = new List<ProductWithQuantity>()
                                {
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product A",
                                        Price = 10.0m,
                                        Quantity = 0
                                    }
                                }
                            }
                        },

                        ExpectedResult = new List<ProductWithQuantity>()
                        {
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product A",
                                        Price = 10.0m,
                                        Quantity = 0
                                    },
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product B",
                                        Price = 10.0m,
                                        Quantity = 0
                                    },
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product C",
                                        Price = 10.0m,
                                        Quantity = 0
                                    },
                                    new ProductWithQuantity()
                                    {
                                        Name = "Product D",
                                        Price = 10.0m,
                                        Quantity = 0
                                    }
                        }

                    }
                }
            };
        }
    }
}
