## Auction System MVC Project
# This project is an Auction system built using ASP.NET Core v8, implementing a 4-layer architecture to ensure separation of concerns and enhance maintainability and scalability. The architecture consists of the following layers:

# Architecture
- Domain Layer: Contains the core business logic and domain entities of the auction system. This layer is responsible for representing the real-world auction processes and ensuring all business rules are enforced.

- Infrastructure Layer: Provides implementations for interacting with external systems, such as databases or third-party services. It includes the data access layer (DAL) and manages data persistence and retrieval operations.

- Application Layer: Acts as an intermediary between the Presentation layer and the Domain layer. It handles application-specific logic and orchestrates operations, using services to perform actions like starting auctions, placing bids, and processing auction results.

- Presentation Layer (MVC): Implements the Model-View-Controller (MVC) pattern to manage the user interface and handle user interactions. This layer is responsible for rendering the views, handling HTTP requests, and providing controllers to manage user input and communicate with the Application layer.

# Design Patterns
The project uses several design patterns to promote code reusability, flexibility, and maintainability:

- Factory Pattern: Utilized for creating objects that follow a standard interface, allowing for easier management and extension of the system as new types of auctions or bidding strategies are introduced.

- Strategy Pattern: Employed to define different algorithms or strategies for auction processing and bidding mechanisms. This pattern allows for dynamically selecting and applying different strategies at runtime, depending on the auction type or specific business rules.

# Key Features
- User Authentication: Secure user registration and login functionality.
- Auction Creation: Allows users to create and manage their auctions.
- Bidding System: Supports placing bids on auctions and dynamically updates the highest bid.
- Auction Expiry and Results: Automatically handles auction expiry and determines winners based on the bidding strategy.

# Technologies Used
- ASP.NET Core v8: The framework used for building the web application.
- Entity Framework Core: Used for data access and ORM.
- SQL Server: The database management system for storing auction and user data.
