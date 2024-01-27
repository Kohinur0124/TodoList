# TodoList
## Task Management System

**Objective:**
The goal of this project is to create a simple Task Management System using .NET technologies, focusing on Web APIs and Blazor (Wasm/Server).

**Project Overview:**
Create a Task Management System that allows users to perform basic CRUD operations on tasks. 

The system should consist of two main components:

### **Web API (Backend):**

- Build a .NET Core Web API to handle CRUD operations for tasks.
- Utilize Entity Framework Core for data persistence.
- Implement endpoints for:
    - Get all tasks
    - Get a specific task by ID
    - Create a new task
    - Update an existing task
    - Delete a task
    - 

### **Blazor (Wasm/Server):**

- Implement a Blazor WebAssembly (Wasm) or Server application to interact with the Web API.
- Create components for:
    - Displaying a list of tasks
    - Viewing details of a task
    - Creating a new task
    - Editing an existing task
    - Deleting a task
- The Task Detail Page should display the following information:
    - Task Title
    - Task Description
    - Task Due Date
    - Task Priority
    - Task State (e.g., To-Do, In Progress, Completed)
    - Task Notes (if any)
    - Any additional properties deemed relevant to a task
