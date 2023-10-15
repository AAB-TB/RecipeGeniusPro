-- Users table with an identity primary key
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(255),
    Password NVARCHAR(255),
    IsAdmin BIT
);

-- Categories table with an identity primary key
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(255)
);

-- Products table with an identity primary key
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(255),
    ProductDescription NVARCHAR(MAX)
);

-- Recipes table with an identity primary key
CREATE TABLE Recipes (
    RecipeID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255),
    RecipeDescription NVARCHAR(MAX),
    CategoryID INT,
    CookingTime NVARCHAR(20), -- Store as string
    ImagePath NVARCHAR(255),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

-- RecipeIngredients table with an identity primary key
CREATE TABLE RecipeIngredients (
    RecipeIngredientID INT IDENTITY(1,1) PRIMARY KEY,
    RecipeID INT,
    ProductID INT,
    Quantity NVARCHAR(50),
    AdditionalAttributes NVARCHAR(MAX),
    FOREIGN KEY (RecipeID) REFERENCES Recipes(RecipeID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

ALTER TABLE RecipeIngredients
DROP COLUMN AdditionalAttributes;