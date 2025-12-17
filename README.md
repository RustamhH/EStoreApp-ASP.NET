EStoreApp – ASP.NET Core Web API Project

Designed and developed a role-based E-commerce / Store Management System using ASP.NET Core and Identity. The system supports secure authentication, authorization, invoice management, and soft-delete data handling with real-world business rules.

Key Highlights:

Implemented role-based authorization (SuperAdmin, Admin, Cashier, Customer) using ASP.NET Identity

Designed and managed core entities: Product, Category, Invoice, InvoiceItem, User, Role, UserToken

Built Product, Category, and Invoice controllers with fine-grained access control per role

Implemented invoice lifecycle management including Sell and Refund invoices with automatic stock updates

Generated unique 12-digit barcode for every invoice

Implemented Soft Delete mechanism (IsDeleted) across all tables to preserve data integrity

Developed authentication flows: Register (Customer only), Login, Email Confirmation, Forgot Password

Enforced email verification before allowing login

Implemented SuperAdmin seeding via configuration (only one SuperAdmin allowed)

Enabled user management:

SuperAdmin: manage all users & send targeted emails (Admins, Cashiers, Customers, or All)

Admin: manage Cashiers and Customers

Integrated email notification system for confirmations and system-wide announcements

Ensured clean architecture & scalable design aligned with enterprise standards

Tech Stack:
ASP.NET Core Web API, Entity Framework Core, Microsoft Identity, SQL Server, RESTful APIs

This project demonstrates strong skills in backend architecture, authorization design, data integrity, and enterprise-level business logic implementation.
