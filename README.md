# Fake Bank Api

## User assumptions
    *   Internal Employee
    *   Consumed over HTTP from web, iOS, Android or other frontends

## Models
    1.  Customer
    ```c#
    public class Customer {
        int Id
        string Name
    }
    ```

    2.  BankAccount
    ```c#
    public class BankAccount {
        int Id
        int CustomerId
        string Name
        double Balance
        DateTime CreatedAt
    }
    ```

    3.  BankAccountTransfer
    ```c#
    public class BankAccountTransfer {
        int Id
        int FromAccountId
        int ToAccountId
        double Balance
        DateTime CreatedAt
    }
    ```

    4.  Transaction
    ```c#
    public class Transaction {
        int Id
        int AccountId
        string Description
        double Amount
        DateTime CreatedAt
    }
    ```

## Requirements
    *   User must be able to create one or more bank accounts
        *   All new bank accounts must have an initial deposit
    *   User must be able to complete a transfer from one account to another
    *   User must be able to get bank account balance
    *   A transaction is created for all account related activity
        *   value must be signed to indicate incoming or outgoing amounts

### Api
    *   POST "/BankAccount/Create"
    *   GET "/BankAccount/Balance/:bankAccountId"
    *   POST "/BankAccountTransfer/Create"
    *   GET "/BankAccountTransfer/History/:bankAccountId"
