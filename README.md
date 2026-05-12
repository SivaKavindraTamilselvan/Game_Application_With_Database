## WORD GAME

## Additional Features Added

- Validations 
    - phone number
    - email
    - password
    - name

- DBContext (connection to the database)

- Exception
    - Email Exception defined for the Email validation
    - Password Exception defined for password (for now password should be between length 8 and 12)
    - Name Exception defined where the username validation (username should be not empty)
    - PasswordIncorrectException defined during login if email is present but password is not correct
    - UserAlreadyRegisterExceptions defined to avoid duplicate user email registration

- Game Service
    - Call the respected repo to add the datas

- Repositories

    to add the datas to the repos where the data are added based on the table

    - Abstract Repository (common functions)
    - GameRepository (add game)
    - ScoreRepository (add score)
    - UserRepository (Login,GetByEmail) - additional fucntions
    - WordGuessHistoryRepository (all guessed words in the game)
    - Word Repository (all words in the wordprovider)

- User Service

    - Create User
    - lOGIN
    - Get User By Email

- Function
    - User Funtion
        - Regsiter (only unique email. repeated email not allowed for registration)
        - Login (check email and check password)
        - get the history of the users logged in

- Input Check & Validation

    - Email
    - Password
    - Name

Game Rules

- The system should secretly choose one 5-letter word.
- The player gets a maximum of 6 attempts.
- The user should enter one guess per attempt.
- If the word is guessed correctly, the game should end immediately.

## FOLDER STRUCTURE

DataBaseAndService

- DBContext

    - create the database connection with the backend 

- Exception

    - Custom Exception defined for InvaidGuess for the words
    - Email Exception defined for the Email validation
    - Password Exception defined for password (for now password should be between length 8 and 12)
    - Name Exception defined where the username validation (username should be not empty)
    - PasswordIncorrectException defined during login if email is present but password is not correct
    - UserAlreadyRegisterExceptions defined to avoid duplicate user email registration

- GameService

    - game id creation for the particular user game table
    - score service to add the scores in the score table
    - Add each word guessed in the game by creating the game id in the starting (seperte table linked by gameid and userid)

- Interface

    - IRepository (To imeplement the basic CRUD opertaion)
    - Based on Requirements only create and getAll are implemented till now

- Models 

    For the models the table are created in the postgres

    - Model

        - User 
        - GameModel (game) (linked to user by userID)
        - WordGuessHistory (guessed word) (in a game every guessed words are added in this table) (linked by game id)
        - Word (contains all the words)
        - Score (for each game ) (linked by game id) (contains score,status etc)

    - DTO 
    
        - UserHistoryDTO (used to fetch the join query attrubute of table user,gamemodel,wordduess,score)

- Repositories

    All the data handling and connections are made in these repositories

    - Abstract Repository
    - GameRepository
    - ScoreRepository
    - UserRepository (Login,GetByEmail) - additional fucntions
    - WordGuessHistoryRepository
    - Word Repository

- UserService

    - GetUsersByEmail(string email)
    - AddUserService(Users users)
    - LoginUser(string email,string password)
    - UserHistory(Users user)


GameCodes

- Word Generator

    - fetch the words from the database and add to the list for random words generation
    - done in constructor during object creation itself
    - cointains the 5 letter word list
    - random fucntion to generate the random 5 letter word from the list

- Validation

    - validation of input
        - cannot be more than 5 letter word
        - cannot be less than 5 letter word
        - cannot contain any kind of special character
        - cannot be whitespace
    - validation of email
    - validation of password (length bw 8 and 12)
    - validation of name

- Feedback

    Here usage of partial class for modular structure of code to avoid long code lines

    - GetFeedback.cs

        - function to compare from the hidden word and the guessed word
        - generate the X,Y,G As per the rule
        - G = Correct letter and position
        - Y = Correct letter and wroung position
        - X = Wroug letter and position
        - Usage of * to avoid repeated loop count
    - PrintFeedback.cs
        - Usage of Console.ForegroundColor for usage of color print in the console and print the result of each feedback

- GameFlow

    - main game 
    - while loop for attempts
    - validation
    - get feedback
    - print feedback
    - score calculate
    - if Y - +5
    - if G - +10
    - End of loop result in score calculate
    - replay option on click 1
    - have 3 levels
    - easy = maximum attempt 6
    - medium = maximum attempt 5
    - hard = maximum attempt 4
    - services are added to call the gameservice to add datas to the database

- ScoreCalculator

    - if won addition of bonus if lost reduction of score
    - here print the score and correct guessed word of lost
    - call the gameservice to add the scores to the database

- InputCheck

    - print the console statments
    - to avoid long length of code
    - check each inputs for validation
        - email
        - password
        - name
        - id (will be used further)

- Functions 

    - UserFunction
        - Add User
        - Login
        - See History
        - Play The game

## EXPECTED USAGE

- Classes and Objects – Game,WordProvider,GuessValidator,FeedbackGenerator,InvalidGuessException,InputAndOutput,ScoreCalculator
- Encapsulation – Usage of Private access modifiers
- Constructors – In Custom Exception
- Methods – For Every class and each functionality implemented using function
- Collections / Lists – For storing previous guessed words
- Loops – for max attempt and retry option
- Conditional Statements – for difficulty level,score calculation,custom exception,print etc
- Custom Exceptions - Implemented
- String Handling – Conversion to upper,trim and char array mainly used

## SCREENSHOTS

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/85062445-80a8-4c60-a4b3-bd58bb3bf610" />

- starting of the application

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/b0967a3a-056d-49e1-8bf4-22329676f639" />

- user email registration validaiton
- allow only one user email for registration
- no duplicates

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/744b27df-03b1-441a-8143-da6e86aabf5e" />

- validate the email address
- throw exception

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/36b3f44a-253f-4d95-93aa-1847c58f7212" />

- password validation(bw 8 and 12 length)

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/228154ef-0067-4677-9241-649cc3f9b0e1" />

- user resgistered successfully

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/4c49a1a2-3a6c-487e-856a-e9e138a2fb6a" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/b8a67e47-86bd-4f95-92d4-d6e1a6659005" />

- login password validations

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/dc78ce01-193d-48ee-b3cf-1ea819785904" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/17763228-d4de-41f1-a217-b7f80a1238d1" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/ec88924f-914f-45db-b669-b52637dcad1f" />

- clicked 1 for playing game
- won the game
  
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/4752efa5-7e3b-4184-b389-f3c0d2e07271" />

- replay the game
- 3 levels
- easy (6 attempt)
- medium (5 attempt)
- hard (4 attempt)

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/cf9f8e97-75e2-43f7-bee8-ae0bb389936c" />

- game lost output

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/f05e7471-4cae-41c8-a072-afb9de87ac51" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/c6a6c116-91d4-4ecd-8f66-7dc0541d6f96" />

- user history along with the join query of all table
- prints every details including the guessed words , score, status etc every details
- query implemented in repository

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/5777b5ac-0891-4e05-9492-48346582789b" />

- check if user exists in database

## PREVIOUS ASSIGNMENTS OUTPUS (ALL THESE FEATURES ARE ALSO THERE NO CHANGES)

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/6897c99b-3591-4cee-b75a-56afaa23340f" />

- E letter correct but wroug position

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/bfe9a405-1f22-4188-ba33-fca864adae1d" />

- E letter correct but wroug position

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/c1e6da28-7eea-40b3-9692-411dbe4085d1" />

- Input length greater than 5 throw exception

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/7d509f31-9942-42dd-8ff2-f463d75849ce" />

- E position correct
- M and L position wrong but position incorrect

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/0502e4bd-e102-4862-a6cc-73387b9b7064" />

- Input length less than 5 throw exception

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/6b2ef463-6355-427a-8f11-41fcde9361d2" />

- Input with numbers and symbol throw exception

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/3d78af7f-d9ea-4c07-90be-cd9af5666d17" />

- Already entered word repeated then throw exception

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/b12d2a7d-fd5f-4272-9c89-c4f9eaffd701" />

- correct word guessed
- game won
- score calculation bonus added

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/06143077-a804-4d81-8694-e55c6febeaed" />

- replay option when 1 clicked

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/40645273-1c4a-42da-a942-018fe11d9539" />

- game lost
- then guesse word displayed

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/d113fdb3-4d4c-4471-b3d8-b40b98b8b03f" />

- medium level (max attempt - 5)

<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/fdebe666-8b93-4625-a65a-0c38079cdced" />

- hard level (max attempt - 4)

## DATABASE


<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/1e1da3b9-fc52-4ee2-87c2-374a41f0ab59" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/8f475888-d696-47f5-b1c9-4613989d3ad6" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/47616acb-6181-4360-91fe-4695219428b7" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/af873c6e-ecb5-4d2c-8713-9a5c73e8180a" />
<img width="3024" height="1964" alt="image" src="https://github.com/user-attachments/assets/4ef3af60-a873-4e02-9be0-75f1732c1b47" />



