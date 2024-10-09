# DataStructures

This repository contains various implementations of common data structures, designed to help developers and learners understand, utilize, and practice these fundamental concepts in computer science. Implemented in C#, the repository focuses on clarity, efficiency, and providing real-world usage examples.

## Table of Contents
- [Introduction](#introduction)
- [Data Structures Implemented](#data-structures-implemented)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction
The **STUDY.DataStructures** repository is created for learning and mastering data structures using C#. It contains implementations of data structures, along with test cases to demonstrate their functionality and efficiency.

## Data Structures Implemented
Here are the data structures currently implemented:

- **Array**
- **Linked Lists**
  - Singly Linked List
  - Doubly Linked List
- **Stack**
- **Queue**
- **Priority Queue**
- **Hash Tables**
- **Trees**
  - Binary Tree
  - Binary Search Tree
- **Heap**

## Installation
To get started with the repository:

1. Clone the repository:

   ```bash
   git clone https://github.com/basemkasem/STUDY.DataStructures.git
   ```
2. Navigate into the repository folder:

    ```bash
    cd STUDY.DataStructures
    ```
3. Build the project using your preferred IDE or the .NET CLI:

    ```bash
    dotnet build
    ```


## Usage
To use the data structures in your own project, you can reference the corresponding class or module.

### Example: Singly Linked List
```bash
using DataStructures;

var list = new LinkedList<int>();
list.InsertLast(10);
list.InsertLast(20);
list.PrintList();  // Output: 10 -> 20
```

## Contributing
Contributions to this repository are encouraged. If you have suggestions or want to add a new data structure, feel free to fork the repository, make changes, and submit a pull request.

### How to Contribute
1. Fork the repository.
2. Create a new branch for your feature or bug fix (git checkout -b feature/new-structure).
3. Make your changes and commit them (git commit -m 'Add new data structure').
4. Push to the branch (git push origin feature/new-structure).
5. Open a pull request and describe your changes.
