# 📚 BookShoppingCart - E-Commerce Platform

A full-featured e-commerce web application built with ASP.NET Core MVC 10.0, demonstrating modern web development practices and enterprise-level architecture patterns.

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2025-CC2927?style=flat&logo=microsoft-sql-server)](https://www.microsoft.com/sql-server)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

---

## 🎥 Live Demo

[![Watch Demo](https://img.shields.io/badge/▶️-Watch%20Demo-FF0000?style=for-the-badge&logo=youtube)](https://youtu.be/ftZGHvdIwIA?si=RezU7nTo1ww1QWRQ)

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Technology Stack](#-technology-stack)
- [Database Schema](#-database-schema)
- [System Architecture](#-system-architecture)
- [Getting Started](#-getting-started)
- [Installation](#-installation)
- [Configuration](#-configuration)
- [Usage](#-usage)
- [Project Structure](#-project-structure)
- [API Endpoints](#-api-endpoints)
- [Screenshots](#-screenshots)
- [Future Enhancements](#-future-enhancements)
- [Contributing](#-contributing)
- [License](#-license)
- [Contact](#-contact)

---

## 🎯 Overview

EcommerseBookUi is a comprehensive e-commerce solution designed for online bookstores. The application demonstrates modern software engineering principles including MVC architecture, Entity Framework Core for data access, Identity Framework for authentication and authorization, and responsive UI design with Bootstrap 5.

### Key Highlights

- **Full CRUD Operations**: Complete Create, Read, Update, Delete functionality for all entities
- **Role-Based Access Control**: Separate interfaces for customers and administrators
- **Real-Time Inventory Management**: Dynamic stock tracking and updates
- **Order Management System**: Complete order lifecycle from cart to checkout
- **Responsive Design**: Mobile-first approach ensuring compatibility across all devices
- **Secure Authentication**: ASP.NET Core Identity with role-based authorization

---

## ✨ Features

### Customer Features
- 🔐 **User Authentication & Authorization**
  - Secure registration and login
  - Password encryption and validation
  - Session management

- 🛒 **Shopping Cart**
  - Add/remove items dynamically
  - Quantity adjustment
  - Real-time price calculation
  - Persistent cart across sessions

- 📚 **Book Catalog**
  - Browse books by category (genre)
  - Search functionality
  - Detailed book information
  - Stock availability display

- 🛍️ **Order Management**
  - Secure checkout process
  - Order history tracking
  - Order status updates
  - Order detail viewing

### Admin Features
- 📊 **Dashboard**
  - Sales analytics
  - Order overview
  - Quick statistics
  - Top selling books report

- 📖 **Book Management**
  - Add new books with images
  - Update book information
  - Delete books
  - Manage book inventory

- 🏷️ **Genre Management**
  - Create and manage book categories
  - Update genre information
  - Delete unused genres

- 📦 **Order Processing**
  - View all orders
  - Update order status (Pending, Shipped, Delivered)
  - View detailed order information
  - Order filtering and search

- 📊 **Inventory Control**
  - Real-time stock monitoring
  - Update stock quantities
  - Low stock alerts
  - Stock history tracking

---

## 🛠 Technology Stack

### Backend
- **Framework**: ASP.NET Core MVC 10.0
- **Language**: C# 12
- **ORM**: Entity Framework Core 10.0
- **Authentication**: ASP.NET Core Identity
- **Database**: Microsoft SQL Server 2025

### Frontend
- **UI Framework**: Bootstrap 5.3
- **JavaScript**: Vanilla JS
- **CSS**: Custom styling with Bootstrap
- **Icons**: Font Awesome / Bootstrap Icons

### Development Tools
- **IDE**: Visual Studio 2022 / Visual Studio Code
- **Version Control**: Git & GitHub
- **Database Management**: SQL Server Management Studio (SSMS)

---

## 🗄️ Database Schema

The application uses a normalized relational database design with the following core entities:

![Database Schema](database-schema-image.png)

### Core Entities

#### **Book**
Primary entity representing books in the inventory
- `Id` (PK): Unique identifier
- `Title`: Book title
- `Author`: Author name
- `Price`: Book price
- `Image`: Cover image path
- `GenreId` (FK): Reference to Genre
- Relationships: Many-to-One with Genre, Many-to-Many with Orders

#### **Genre**
Categorization of books
- `Id` (PK): Unique identifier
- `GenreName`: Category name
- Relationships: One-to-Many with Books

#### **Order**
Customer orders
- `Id` (PK): Unique identifier
- `UserId` (FK): Reference to AspNetUsers
- `OrderDate`: Timestamp
- `TotalAmount`: Order total
- `OrderStatus`: Status enumeration
- Relationships: Many-to-One with User, One-to-Many with OrderDetails

#### **OrderDetail**
Individual items within an order
- `Id` (PK): Unique identifier
- `OrderId` (FK): Reference to Order
- `BookId` (FK): Reference to Book
- `Quantity`: Number of books
- `UnitPrice`: Price per unit
- Relationships: Many-to-One with Order and Book

#### **ShoppingCart**
User shopping carts
- `Id` (PK): Unique identifier
- `UserId` (FK): Reference to AspNetUsers
- Relationships: One-to-One with User, One-to-Many with CartDetails

#### **CartDetail**
Items in shopping cart
- `Id` (PK): Unique identifier
- `ShoppingCartId` (FK): Reference to ShoppingCart
- `BookId` (FK): Reference to Book
- `Quantity`: Number of books
- Relationships: Many-to-One with ShoppingCart and Book

#### **Stock**
Inventory tracking
- `Id` (PK): Unique identifier
- `BookId` (FK): Reference to Book
- `Quantity`: Available stock
- Relationships: One-to-One with Book

#### **AspNetUsers** (Identity)
User accounts managed by ASP.NET Core Identity
- Standard Identity fields
- Extended with custom properties
- Relationships: One-to-Many with Orders and ShoppingCarts

---

## 🏗 System Architecture

The application follows the MVC (Model-View-Controller) architectural pattern with clear separation of concerns:

```
BookShoppingCartMvcUI/
│
├── Controllers/           # Handle HTTP requests and responses
│   ├── HomeController.cs
│   ├── BookController.cs
│   ├── CartController.cs
│   ├── AdminController.cs
│   └── OrderController.cs
│
├── Models/               # Data entities and business logic
│   ├── Book.cs
│   ├── Genre.cs
│   ├── Order.cs
│   ├── OrderDetail.cs
│   ├── ShoppingCart.cs
│   ├── CartDetail.cs
│   └── Stock.cs
│
├── Views/                # UI templates (Razor views)
│   ├── Home/
│   ├── Book/
│   ├── Cart/
│   ├── Admin/
│   └── Shared/
│
├── Data/                 # Database context and configurations
│   ├── ApplicationDbContext.cs
│   └── DbSeeder.cs
│
├── Repositories/         # Data access layer (Repository pattern)
│   ├── ICartRepository.cs
│   ├── IBookRepository.cs
│   └── IOrderRepository.cs
│
└── wwwroot/              # Static files (CSS, JS, images)
    ├── css/
    ├── js/
    └── images/
```

### Design Patterns Implemented

1. **MVC Pattern**: Separation of business logic, data, and presentation
2. **Repository Pattern**: Abstraction layer for data access
3. **Dependency Injection**: Loose coupling and testability
4. **Unit of Work**: Transaction management
5. **Identity Pattern**: Authentication and authorization

---

## 🚀 Getting Started

### Prerequisites

Ensure you have the following installed on your machine:

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- [SQL Server 2025](https://www.microsoft.com/sql-server/sql-server-downloads) or SQL Server Express
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)
- [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) - Optional but recommended

---

## 📥 Installation

### Step-by-Step Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/YOUR_USERNAME/BookShoppingCart-Mvc.git
   cd BookShoppingCart-Mvc
   ```

2. **Configure Database Connection**
   
   Open `appsettings.json` and update the connection string:
   
   ```json
   {
     "ConnectionStrings": {
       "conn": "Server=YOUR_SERVER_NAME;Database=BookShoppingCartMvc;Integrated Security=true;TrustServerCertificate=True;"
     }
   }
   ```

   **Example for local SQL Server:**
   ```json
   {
     "ConnectionStrings": {
       "conn": "Server=localhost;Database=BookShoppingCartMvc;Integrated Security=true;TrustServerCertificate=True;"
     }
   }
   ```

   **Example with SQL Server Authentication:**
   ```json
   {
     "ConnectionStrings": {
       "conn": "Server=YOUR_SERVER_NAME;Database=BookShoppingCartMvc;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
     }
   }
   ```

3. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

4. **Build the Project**
   ```bash
   dotnet build
   ```

5. **Run the Application**
   ```bash
   dotnet run
   ```

6. **Access the Application**
   - Open your browser and navigate to: `https://localhost:5001` or `http://localhost:5000`
   - The first run will automatically:
     - Create the database
     - Apply migrations
     - Seed sample data
     - Create admin account

---

## ⚙️ Configuration

### First Run Initialization

When you run the application for the first time, it automatically:

1. ✅ Creates the database schema
2. ✅ Seeds sample data (books, genres, etc.)
3. ✅ Creates default admin account
4. ✅ Initializes stock for all books

### Admin Account

**Default Credentials:**
- **Email**: `admin@gmail.com`
- **Password**: `Admin@123`

> ⚠️ **Security Note**: Change the default admin password immediately in production environments

### Environment Variables

You can override settings using environment variables:

```bash
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__conn="YOUR_CONNECTION_STRING"
```

---

## 💻 Usage

### For Customers

1. **Browse Books**
   - Visit the homepage to see featured books
   - Use category filters to browse by genre
   - Search for specific titles or authors

2. **Add to Cart**
   - Click "Add to Cart" on any book
   - Adjust quantities in the cart
   - View real-time price updates

3. **Checkout**
   - Review your cart
   - Proceed to checkout
   - Complete order placement

4. **Track Orders**
   - View order history in your profile
   - Check order status
   - View detailed order information

### For Administrators

1. **Login as Admin**
   - Use admin credentials
   - Access admin dashboard

2. **Manage Books**
   - Navigate to Books section
   - Add new books with images
   - Update or delete existing books

3. **Manage Genres**
   - Create new categories
   - Edit or remove genres

4. **Process Orders**
   - View all customer orders
   - Update order status
   - View order details

5. **Manage Inventory**
   - Monitor stock levels
   - Update stock quantities
   - View top-selling books

---

## 📁 Project Structure

```
BookShoppingCart-Mvc/
│
├── BookShoppingCartMvcUI/        # Main application project
│   ├── Controllers/               # MVC Controllers
│   ├── Models/                    # Domain models
│   ├── Views/                     # Razor views
│   ├── Data/                      # Database context
│   ├── Repositories/              # Data access layer
│   ├── wwwroot/                   # Static files
│   ├── appsettings.json          # Configuration
│   └── Program.cs                 # Application entry point
│
├── screenshots/                   # Application screenshots
├── .gitignore                     # Git ignore rules
└── README.md                      # This file
```

---

## 🔌 API Endpoints

### Public Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/` | Home page with featured books |
| GET | `/Book/Details/{id}` | Book details page |
| GET | `/Book/DisplayByGenre/{id}` | Books filtered by genre |
| POST | `/Cart/AddItem` | Add book to cart |
| GET | `/Cart/GetUserCart` | View shopping cart |
| POST | `/Order/Checkout` | Place order |

### Admin Endpoints (Require Admin Role)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/Admin/Dashboard` | Admin dashboard |
| GET | `/Book/GetBooks` | Get all books |
| POST | `/Book/AddBook` | Create new book |
| PUT | `/Book/UpdateBook/{id}` | Update book |
| DELETE | `/Book/DeleteBook/{id}` | Delete book |
| GET | `/Genre/GetGenres` | Get all genres |
| POST | `/Genre/AddGenre` | Create new genre |
| GET | `/Order/GetOrders` | View all orders |
| PUT | `/Order/UpdateOrderStatus` | Update order status |
| GET | `/Stock/ManageStock` | View inventory |
| PUT | `/Stock/UpdateStock` | Update stock quantity |


---

## 🔮 Future Enhancements

- [ ] **Payment Gateway Integration** (Stripe, PayPal)
- [ ] **Email Notifications** for order updates
- [ ] **Advanced Search** with filters and sorting
- [ ] **Product Reviews & Ratings** system
- [ ] **Wishlist** functionality
- [ ] **Recommendation Engine** based on purchase history
- [ ] **Multi-language Support** (i18n)
- [ ] **PDF Invoice Generation** for orders
- [ ] **Real-time Chat Support** for customers
- [ ] **Mobile Application** (Xamarin/MAUI)
- [ ] **Analytics Dashboard** with charts and graphs
- [ ] **Social Media Integration** for sharing
- [ ] **Coupon & Discount** system
- [ ] **API Documentation** with Swagger/OpenAPI

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. **Fork the Project**
2. **Create your Feature Branch**
   ```bash
   git checkout -b feature/AmazingFeature
   ```
3. **Commit your Changes**
   ```bash
   git commit -m 'Add some AmazingFeature'
   ```
4. **Push to the Branch**
   ```bash
   git push origin feature/AmazingFeature
   ```
5. **Open a Pull Request**

### Coding Standards

- Follow C# coding conventions
- Write meaningful commit messages
- Include unit tests for new features
- Update documentation as needed
- Ensure all tests pass before submitting PR

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Contact

**Your Name**
- GitHub: [@mohamedkrouf](https://github.com/mohamedkrouf)
- LinkedIn: [Mohamed Kr](https://www.linkedin.com/in/mohamed-kr-b17797341/)
- Email: mohamed.krouf@isimg.tn

**Project Link**: [https://github.com/mohamedkrouf/EcommerceBookUi](https://github.com/mohamedkrouf/EcommerceBookUi)

---

## 🙏 Acknowledgments

- Followed a Tutorial and built the project along Original tutorial by [Ravindra Devrani](https://github.com/rd003)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core)
- [Bootstrap Documentation](https://getbootstrap.com/docs)
- Stack Overflow community for troubleshooting support

---

## 📊 Project Status

**Current Version**: 2.0.0  
**Status**: ✅ Production Ready  
**Last Updated**: 19 December 2025

### Version History

- **v2.0.0** (19 Dec 2025): Added details , polished User Interface and Imporved Code Readability
- **v1.5.0** (30 Nov 2025): Added admin dashboard and reports
- **v1.0.0** (20 Nov 2025): Initial release with core features

---

<div align="center">
  
**Built with ❤️ BY Krouf Mohamed**

⭐ Star this repository if you find it helpful!

</div>
