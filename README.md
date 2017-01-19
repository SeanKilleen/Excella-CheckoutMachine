# Excella-CheckoutMachine
A demo project for Excella's CSD class. Built from the ground up using TDD to show a progression from class library to web app from a TDD approach.

Our goal is to show a lasting history of how you can solve a problem like this using a test-driven approach and bite-sized requirements.

# Introducing the Problem: the "Self-Checkout Exercise"
This is a common kata-style problem. The example we'll be using can be found below.

You are a customer using a self-checkout at a supermarket. You scan the stock keeping unit (sku) of each product and review the total price you need to pay. If you have a bonus card, you can scan your bonus card to receive discounts. Current deals with bonus card include ½ off salsa as well as a buy 2 get 1 free for chips. There is a 50 cents surcharge for tobacco products. All scanned products must make a call to a remote inventory control system that logs the scanned products for inventory control purposes (assume a REST webservice call). A separate call is also made to an id verification system that will randomly select age-restricted products (e.g. alcohol and cigarettes) for age verification. A product selected for age verification cannot be added to the cart, and an `AgeVerificationException` should be thrown which asks the customer to take their item to a clerk for verification.

The store only sells the following products:

| Product | Sku | Price (cents) | 
| ------- | --- | ----- | 
| Chips | 123 | 200 |
| Salsa | 456 | 100 | 
| Wine | 789 | 1000 | 
| Cigarettes | 111 | 500 |

You must adhere to the following rules:

* The class must be called `CheckoutMachine`
* You must have only 2 public methods -- all other methods and variables must be private:
 * public void Scan (int sku)
 * public int GetTotal()

Other helpful notes:

* You are encouraged to take baby steps and solve for simple cases first.
* The bonus card concept is implicit; you may choose any SKU to represent a bonus card


An example test scenario to build to: "When I scan 5 chips, 3 salsas, 2 wine, 2 cigarettes, and a bonus card, the total should be 4050".


# What will this repo do?

* We will attempt to solve this kata example in a TDD fashion
* We will commit often to the master branch, preferably at least every red/green/refactor cycle, if not more often.
* We will attempt to break the work down into github issues & PRs, so that you can follow along with the work as it progresses and really get a sense of the work breakdown.

# Prerequisites
Your experience working on this project will work best if you have:

* .NET 4.5 
* Microsoft Visual Studio 2015 or later (though 2013 should work)

# How do I build this project?
* Clone or fork the project on Github (or download the source as a zip file)
* Open the Excella.CheckoutDemo Visual Studio solution in the `\src` folder
* Build the project, which should restore the nuget packages and build the project.

# How do I run the tests?
For this particular project, we're using NUnit and the NUnit3TestAdapter, which means that you should be able to run your tests from within Visual Studio.


# How can I follow along?
We attempt to make small, incremental changes as we complete the project, so the best way to follow along is:

* Look at the issue history in Github. We'll be attempting to break down our assignments into small tasks using Github Issues. You should be able to see the order in which they're closed.
* Look at the source code history. All commits will make it back to the master branch and you should be able to follow along with each pull request and all of their changes.
 * We'll attempt to keep pull requests small to make them easily manageable. 
 * Follow the progress and look for Red/green/refactor cycles, the committing of changes related to a certain issue, and the various refactoring activities that will be submitted.

 # Comments and Critique Welcome!
 While I've done this before in various formats, I never mind learning a thing or two. Did this help you? Is there something you'd improve? Drop a note and let me know! You can file an issue here on GitHub, send me an e-mail at [SeanKilleen@gmail.com](mailto:SeanKilleen@gmail.com), or talk to me [@sjkilleen on Twitter](http://twitter.com/sjkilleen). You can also find me blogging (semi-)regularly at [SeanKilleen.com](http://SeanKilleen.com). 

 Say hi! I don't bite.