using RecipesCRUD_Template.Core.Models;
using RecipesCRUD_Template.DataAccess.Services;
using RecipesCRUD_Template.DataAccess.SQLite;

namespace RecipesCRUD_Template.Test;

/// <summary>
/// Class <c>SQLiteTest</c> is responsible for testing the <see cref="DataAccessService" /> with a SQLite database.
/// </summary>
public class SQLiteTest
{
    private const string _dbPath = "test.sqlite";

    /// <summary>
    /// Class <c>A_Preparation</c> creates a new SQLite database file.
    /// </summary>
    [Collection("SqliteTestCollection")]
    public class A_Preparation
    {
        [Theory]
        [InlineData(_dbPath)]
        private void Setup(string dbPath)
        {
            File.Delete(dbPath);

            var contextFactory = new AppDbContextFactorySQLite(_dbPath);

            using var context = contextFactory.CreateDbContext();
            contextFactory.CreateDbContext().EnsureDbCreated();
        }
    }

    /// <summary>
    /// Class <c>B_CreationTest</c> tests the inserting function.
    /// </summary>
    [Collection("SqliteTestCollection")]
    public class B_CreationTest
    {
        [Theory]
        [InlineData(_dbPath)]
        private async void CreationTest(string dbPath)
        {
            var contextFactory = new AppDbContextFactorySQLite(dbPath);
            var das = new DataAccessService(contextFactory);

            var materialCategory = new MaterialCategory
            {
                Name = "Test Material Category #1"
            };
            var materialCategory2 = new MaterialCategory
            {
                Name = "Test Material Category #2"
            };

            materialCategory.SubCategories.Add(materialCategory2);

            var material = new Material
            {
                Name = "Test Material",
                Category = materialCategory
            };

            var recipeCategory = new RecipeCategory
            {
                Name = "Test Recipe Category #1"
            };
            var recipeCategory2 = new RecipeCategory
            {
                Name = "Test Recipe Category #2"
            };

            recipeCategory.SubCategories.Add(recipeCategory2);

            var materialValuePair = new MaterialValuePair
            {
                Material = material,
                Value = 0.123
            };

            var recipe = new Recipe
            {
                Name = "Test Recipe",
                Category = recipeCategory
            };
            recipe.Materials.Add(materialValuePair);

            await das.Create(materialCategory);
            await das.Create(materialCategory2);
            await das.Create(material);
            await das.Create(recipeCategory);
            await das.Create(recipe);
            await das.Create(materialValuePair);

            Assert.Equal(2, (await das.GetAll<MaterialCategory>()).Count);
            Assert.Single(await das.GetAll<Material>());
            Assert.Equal(2, (await das.GetAll<RecipeCategory>()).Count);
            Assert.Single(await das.GetAll<Recipe>());
            Assert.Single(await das.GetAll<MaterialValuePair>());
        }
    }

    /// <summary>
    /// Class <c>C_ReadTest</c> tests the get/read function.
    /// </summary>
    [Collection("SqliteTestCollection")]
    public class C_ReadTest
    {
        [Theory]
        [InlineData(_dbPath)]
        private async void ReadTest(string dbPath)
        {
            var contextFactory = new AppDbContextFactorySQLite(dbPath);
            var das = new DataAccessService(contextFactory);

            var material = (await das.GetAll<Material>()).Where((m) => m.Name == "Test Material").First();
            Assert.NotNull(material);
            Assert.NotNull(material.Category);

            var materialCategory = (await das.GetAll<MaterialCategory>()).Where((mc) => mc.Name == "Test Material Category #1").First();
            Assert.NotNull(materialCategory);
            Assert.Null(materialCategory.Parent);
            Assert.NotEmpty(materialCategory.Materials);
            Assert.NotEmpty(materialCategory.SubCategories);

            var materialCategory2 = (await das.GetAll<MaterialCategory>()).Where((mc) => mc.Name == "Test Material Category #2").First();
            Assert.NotNull(materialCategory2);
            Assert.NotNull(materialCategory2.Parent);
            Assert.Empty(materialCategory2.Materials);
            Assert.Empty(materialCategory2.SubCategories);

            var recipe = (await das.GetAll<Recipe>()).Where((r) => r.Name == "Test Recipe").First();
            Assert.NotNull(recipe);
            Assert.NotNull(recipe.Category);
            Assert.NotEmpty(recipe.Materials);

            var recipeCategory = (await das.GetAll<RecipeCategory>()).Where((rc) => rc.Name == "Test Recipe Category #1").First();
            Assert.NotNull(recipeCategory);
            Assert.Null(recipeCategory.Parent);
            Assert.NotEmpty(recipeCategory.SubCategories);
            Assert.NotEmpty(recipeCategory.Recipes);

            var recipeCategory2 = (await das.GetAll<RecipeCategory>()).Where((rc) => rc.Name == "Test Recipe Category #2").First();
            Assert.NotNull(recipeCategory2);
            Assert.NotNull(recipeCategory2.Parent);
            Assert.Empty(recipeCategory2.SubCategories);
            Assert.Empty(recipeCategory2.Recipes);

            var materialValuePair = (await das.GetAll<MaterialValuePair>()).Where((mvp) => mvp.Value == 0.123).First();
            Assert.NotNull(materialValuePair);
            Assert.NotNull(materialValuePair.Material);
            Assert.NotNull(materialValuePair.Recipe);
        }
    }

    /// <summary>
    /// Class <c>D_UpdateTest</c> tests the update function.
    /// </summary>
    [Collection("SqliteTestCollection")]
    public class D_UpdateTest
    {
        [Theory]
        [InlineData(_dbPath)]
        private async void UpdateTest(string dbPath)
        {
            var newMaterialName = "Newly named Test Material";
            var newMaterialCategoryName = "Newly named Test Category";
            var newRecipeName = "Newly named Test Recipe";
            var newRecipeCategoryName = "Newly named Test Category";
            var newMaterialValuePairValue = 0.222f;

            {
                var contextFactory = new AppDbContextFactorySQLite(dbPath);
                var das = new DataAccessService(contextFactory);

                var material = (await das.GetAll<Material>()).Where((m) => m.Name == "Test Material").First();
                Assert.NotNull(material);
                
                var materialCategory = (await das.GetAll<MaterialCategory>()).Where((mc) => mc.Name == "Test Material Category #1").First();
                Assert.NotNull(materialCategory);
                
                var recipe = (await das.GetAll<Recipe>()).Where((r) => r.Name == "Test Recipe").First();
                Assert.NotNull(recipe);
                
                var recipeCategory = (await das.GetAll<RecipeCategory>()).Where((rc) => rc.Name == "Test Recipe Category #1").First();
                Assert.NotNull(recipeCategory);
                
                var materialValuePair = (await das.GetAll<MaterialValuePair>()).Where((mvp) => mvp.Value == 0.123).First();
                Assert.NotNull(materialValuePair);

                material.Name = newMaterialName;
                materialCategory.Name = newMaterialCategoryName;
                recipe.Name = newRecipeName;
                recipeCategory.Name = newRecipeCategoryName;
                materialValuePair.Value = newMaterialValuePairValue;

                await das.Update(material);
                await das.Update(materialCategory);
                await das.Update(recipe);
                await das.Update(recipeCategory);
                await das.Update(materialValuePair);


            }
            {
                var contextFactory = new AppDbContextFactorySQLite(dbPath);
                var das = new DataAccessService(contextFactory);

                var material = (await das.GetAll<Material>()).Where((m) => m.Name == newMaterialName).First();
                Assert.NotNull(material);

                var materialCategory = (await das.GetAll<MaterialCategory>()).Where((mc) => mc.Name == newMaterialCategoryName).First();
                Assert.NotNull(material);

                var recipe = (await das.GetAll<Recipe>()).Where((r) => r.Name == newRecipeName).First();
                Assert.NotNull(recipe);

                var recipeCategory = (await das.GetAll<RecipeCategory>()).Where((rc) => rc.Name == newRecipeCategoryName).First();
                Assert.NotNull(recipeCategory);

                var materialValuePair = (await das.GetAll<MaterialValuePair>()).Where((mvp) => mvp.Value == newMaterialValuePairValue).First();
                Assert.NotNull(recipeCategory);
            }
            

        }
    }
}