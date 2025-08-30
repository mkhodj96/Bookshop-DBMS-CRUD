# Bookshop Database Management System

**Database Project #19**  
A C# Windows Forms application for managing a bookshop database.  
The system allows users to **add, search, update, and delete** book information along with author and publisher details.  

---

## Database Schema

The database contains the following tables:

- **Authors** (`author_id`, `firstName`, `lastName`, `email`)  
- **Publishers** (`publisher_id`, `publisherFullName`)  
- **Title** (`isbn`, `title`, `editionNumber`, `copyright`, `publisher_id`, `price`)  
- **AuthorISBN** (mapping table: `author_id`, `isbn`)  

Entity relationships ensure that:  
- Each book has a publisher.  
- Each book can be linked to one or more authors.  

---

## Features

### 1. Add New Books  
- Enter book details (ISBN, Title, Edition Number, Copyright, Publisher, Price).  
- Enter author details (ID, Name, Email).  
- Enter publisher details (if not already in DB).  
- Checkbox options to reuse existing author/publisher records.  

### 2. Search, Update & Delete  
- **Search:**  
  - Select which table to query.  
  - Choose column and search value.  
- **Update:**  
  - Search and select data.  
  - Edit fields in the provided text boxes.  
  - Click **Update** to save changes.  
- **Delete:**  
  - Search and select a record.  
  - Click **Delete** to remove it from the database.  

---

## Prerequisites
- **.NET Framework / Visual Studio**  
- **SQL Server** (or compatible relational database)  
- Basic knowledge of:
  - C# Windows Forms  
  - Relational Databases (ERD, primary/foreign keys)  

---

## How to Run
1. Clone the repository.  
2. Set up the database using the provided schema (`Authors`, `Publishers`, `Title`, `AuthorISBN`).  
3. Update the connection string in the application code to match your database.  
4. Build and run the solution in **Visual Studio**.  

---

## Applications
- Bookstore and library management.  
- Educational project for practicing **CRUD operations** with databases.  
- Demonstration of **Windows Forms + Database integration**.  

