# Service Request Status

## Table of Contents
1. [Overview](#overview)
2. [Prerequisites](#prerequisites)
3. [Data Structures Overview](#data-structures-overview)
    - [Binary Search Tree (BST)](#binary-search-tree-bst)
4. [Conclusion](#conclusion)

---

## Overview

The **Service Request Status** application is a feature for managing and displaying the status of service requests. It allows users to view the current status, details, and progress of various service requests related to municipal services.

This application uses **Razor Pages** and the **.NET Core Framework** to provide an interactive web interface. The service requests are stored in a custom **Binary Search Tree (BST)**, which enables efficient insertion and retrieval operations.

---

## Prerequisites

Before compiling and running this project, make sure you have the following tools installed:

- **.NET Core SDK**: [Download .NET Core SDK](https://dotnet.microsoft.com/download)
- **Visual Studio**: [Download Visual Studio](https://visualstudio.microsoft.com/) (optional but recommended for development)
- **Web Browser**: To view the web application (e.g., Chrome, Firefox, Edge)

---

##Data Structures Overview

**Binary Search Tree (BST)**
The Binary Search Tree (BST) is used to store and manage the service requests in the application. It provides efficient insertion and retrieval of service request records by their ID.

Role of BST:
The BST ensures that service requests are always sorted by their unique ID. This allows for fast retrieval of requests, especially when the system grows larger, because it minimizes the number of comparisons needed to find a specific request.

Explanation of BST Operations:
  1. Insertion: When a new service request is created, it is inserted into the BST. The insertion operation compares the ID of the new request with the nodes in the tree, ensuring that the tree remains sorted. If the new request's ID is smaller than the current     node's ID, the insertion moves to the left child; otherwise, it moves to the right child. This process ensures the BST property is maintained.
  2. Traversal: To display all the service requests on the front end, we use an in-order traversal of the BST. An in-order traversal visits nodes in ascending order of their ID, which guarantees that the service requests are displayed in a sorted manner.

Efficiency:
Insertion: O(log n) on average, assuming the tree is balanced. If the tree becomes unbalanced, the time complexity could degrade to O(n).
Traversal: O(n), where n is the number of service requests, since each node must be visited once.

---

##Conclusion

This application provides an efficient and scalable solution for managing and viewing service requests using a Binary Search Tree (BST). The BST ensures that service requests are sorted and can be efficiently inserted or retrieved based on their ID. While the search functionality has been removed, the core functionality remains fast and effective for handling service requests.

Feel free to modify and extend the application for additional features, such as more complex filtering, sorting, or searching mechanisms.
