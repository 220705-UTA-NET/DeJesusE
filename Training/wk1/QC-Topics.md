- Concepts
  - OOP
    - Encapsulation - idea of bundling up data and methods that perform a certain functionality into one unit, i.e. the class, and creating limitations on how other classes can access
      said fields and methods (Links up with access modifiers). This way, we can protect the class's fields from being modified in a way that breaks it which may create errors
      within the program.
    - Abstraction - the idea of hiding any complexity and unnecessary details from the user or from a outside class and instead only showing the functionality. Purpose is to allow for other
      classes to use it without having to worry about the intricacies of the underlying structure.
    - Inheritance - allows us to expand the functinality of a class by allowing it to share fields and methods from another class and expanding upon it without having to re-write code. Purpose to prevent us from  
      having to re-write code and to expand the core-code dynamically.
    - Polymorphism - objects of a derived class may be treated as objects of a base class in places such as method parameters and collections or arrays. Base classes may define and implement virtual methods, and derived classes can override them, which means they provide their own definition and implementation.
- What is GIT?

  - What is version control? What are the types and where does GIT fit into this?

    - A version control software / system allows us to keep track of changes made to our code, so that if necessary we can revert it back to an earliar state before said changes occured. This is done by either of two ways. The first one method of implementing this is by having a single or central copy of your project which we can pull from and commit to.
      The other way, which is way GIT does it, is that instead of having a central copy of project we instead have multiple copies of a project which are stored locally on your computer. Services like GITHUB expands upon this by allowing developers to also have a centralized copy in combination with their local copy.
    - Stages in GIT Life Cycle: Working Directory, Staging Area, GIT directory
      - Working Directory - project is either being tracked by GIT or not. In order to get GIT to track your project, you need to use git init which will initialize a GIT repository containing your project.
      - Staging Area - where you group, add, and organize files to be committed to GIT for tracking versions of your project. To add files to the staging area, you use the git add command followed by the files you which to add.
        - Untracked - file exists, but are not part of GIT's version control
        - Staging Area - files have been added to GIT's version control, but changes haven't been committed
        - Committed - changes have been committed
      - GIT Directory - metadata regarding the project along with the author and any message created are recorded by GIT and stored in the GIT directory containing metadata on the project's history. To do this, you use the command, git commit.
    - Commands:
      1. git status - displays the paths of files or folders that have either been added or changed from the current HEAD commit (Which denotes the last committed state)
      2. git log - list commits that were made. Contains the date, author, and checksum of the commit
      3. git clone - creates a forked repository of a pre-existing server repository
         3.5. git remote - creates a connection between two repositories. Usually used to create a connection between a local repository with the main or central repository located within a server
      4. git reset - it can modify the index or change which commit a branch head is currently pointing at. Therefore the command may alter existing history by changing the commit that a branch references
      5. git push - used to upload a local repository into a remote repository
      6. git pull - used to download changes made in a remote repository to the local repository
      7. git fetch - downloads commits, files, and referances from a remote repository into your local repository without forcing you to merge the changes into your repository.
      8. git merge - incorporates changes from two different commits into the current branch
      9. git revert - creates a new commit that undoes changes made from a previous commit without modifying the project existing history
      10. git checkout - switches branches or commits

  - GIT repository is the .git folder inside a project which tracks changes made to files / folder within your project
  - Branches/Branching: When performing a commit in GIT, you are creating a snapshot of your project and adding it a tree-structure. When branching, you are then creating a new pointer separate from the master pointer (Which is the initial pointer), that way you can commit additional changes without affecting the main branch or project.
  - Pull request - requesting a merge
  - Repository Permissions - controls who can view, modify, and commit to your repository thereby restricting access to your repository
  - Merge Conflicts and resolutions - occurs when two commits had made different changes to the same line . The best way to resolve this is to edit the conflicted files in both versions, commit, and then finalize the merge. git status and git log --merge will identify conflicted files and git diff will find the differences between states of a repository or file. Another solution will be to use git checkout or git reset --mixed to undo changes to the file for changing the branch.
  - Forking - provides the developer a localized version of the central, or server side, codebase. Allows for contributors to have their contributions added to a project without requiring them to push/pull to/from a central repository
  - .gitignore - file containing a list of filesnames for git to ignore when staging and commiting a directory

- Dotnet SDK - a set of libraries and tools that allow developers to create .NET applications and libraries. It contains,
  - .NET CLI (Command Line Interface), which is a cross-platform toolset used for creating, developing, and running .NET applications
  - Common Language Runtime (CLR), which is the virtual machine used in executing .NET programs and provides services such as memory management, exception handling, thread management, and garbage collection for your program
  - Common Language Infrastructure (CLI)- allows for multiple high-level languages to be used across multiple platforms
- C# Topics
  - Access modifiers (public, private, internal, protected): controls access to a field/method/ or class
    - public - the field/method is accessible to all classes
    - private - the field/method is only accessible objects of the same class
    - protected - the field/method is accessible to objects of the same class or
      objects iherited from that class
    - internal - the field/method is only accessible from objects of classes that exist in the same assembly
    - You can also have a combination of protected internal and private protected
  - Data Types
    - Value vs. Reference types
      - Value (Built-In Types): value is stored directly into its own memory space within the stack
        - bool - stores a boolean value of either true or false (1 bit)
        - int - stores whole numbers that can be represented in 4 bytes
        - long - stores whole numbers that can be represented in 8 bytes
        - float - stores floating point numbers that can be represented by 4 bytes
        - double - stores floating point numbers that can be represented by 8 bytes
        - char - stores a single unicode character/letter; size 2 bytes
        - decimal - stores floating point numbers that can be represented by 16 bytes
      - Reference : value is stored in the heap with a pointer variable pointing to it from the stack
  - Control Flow - changes the order in which statements are runned
    - Conditionals -checks a condition to determine whether or not to run a code  
       block
      - IF ... ELSE - checks if a condition is true before performing a code block.  
         Can have one or multiple checks and can have default case  
         should all condition check out as false. Once one condition  
         is meet, the program exit out of the IF-ELSE statement.
      - Switch statement - checks if an expression matches a value before executing  
         a code block. Once code block is executed, it will then  
         continue checking each case value until it encounters a  
         break statement.
    - Loops - a code block is carried out repeately until a condition is meet
      - for - will perform a code block a finite number of times
      - while - will perform a code block repeatedly until a condition evaluates as  
         false
      - do while - will perform a code block once before performing repeatedly  
         until a condition evaluates as false
      - foreach - will iterate through a list or array and perform a code block on  
         each element until it runs out of elements
  - Operators
    - Logical
      - Standard: ||, &&, ! => Returns a boolean
    - Arithmetic
      - Standard: +, -, /, \*, \*\*, % => Returns the result
    - Comparative
      - > =, >, <, <=, ==, != => Returns a boolean
  - Classes
    - Fields / States / Members
      - Refers to class variables. Usually represents attributes of our object or  
        contains data relating to the object.
    - Methods
      - The functionality of an object. Refers to behaviors that the object may have.
  - Namespaces - denotes the assembly that the class belongs to. Used to group  
     classes together to avoid name collisions by providing a scope
    for identifiers.
  - Exceptions - objects representing error events. When an error occurs, an exception object
    is created is thrown (throw keyword) where it is then catched by the CLR  
     where it finds the most appropriate handler to handle the error.
    - Throwing exceptions - you can manually throw an exception by utilizing the throw keyword followed by the exception object of the type you want to throw
      ex. throw new [Exception];
    - Exception handling - you can manually handle an exception by utilizing a try-catch block
      ex.
      try {
      ...
      } Catch ([Exception Type] [variable name]){
      ...
      }
  - Abstract classes - type of class that contains methods that haven't been implemented or are
    incomplete. Classes that inherit an abstract class must then implement said
    methods or complete said methods via override.
    - You declare a method abstract if you want a child class to implement it: abstract void method();
    - You can provide a default implementation for a method and have a child class modify it: virtual void method();
  - Overriding / Overloading
    - Overriding - is the idea of replacing a method with another implementation of the method. New method must have the same
      name, return type, # of parameters (In the same order), and same data type for each parameter.
    - Overloading - is the idea of having multiple methods of the same name but with a different set of parameters
  - Type Conversion:
    - Implicit - doesn't require any special syntax. Can be done if data will not be lost when doing the conversion. Ex. double d = [int] i
    - Explicit - a keyword or method is used to convert the type of a value to another type without losing any data in the process. Ex. int i = CInt(d);
  - Data structures: Arrays, Lists, stacks, queues
    - Array - an collection of elements. Size is set once initialized and cannot be changed.
    - Lists - an collection of elements where size can change
    - Stacks - a collection of elements following the First In Last Out Principle
    - Queues - a collection of elements following the First In First Out Principle
  - Memory Architecture
    - Stack/Heap
      - Stack - located in upper memory. Where the memory of most things are allocated
        such as variables, statements, methods, loops etc. - unflexible - static allocation
      - Heap - located in lower addresses in memory. Where objects that are dynamically
        created during runtime are stored - dynamic allocation
  - Constructor methods, : base()
    - Constructor method - creates objects of a class
    - : base () - references the parent constructor and can be used to pass parameters to it
- Bash - is the UNIX shell, or command language intrepreter, for the GNU operating system and command line language.
  Similiar to PowerShell and Command prompt in windows. Allows for greater flexibility in what you can do as
  well as greater performance as you don't need to navigate with your mouse to perform a function. Also, when
  done in conjuction with a scripting language, allows for automation of tasks.

  - ls - List - lists files and directories within the path given (Defaults to current directory)
  - mkdir - creates a new directory with the name provided to it
  - touch - originally meant to update the timesheet of a file, it has been used mostly to create files
  - cat - concatenate - reads through a file sequentially and writes it to standard output (a file descripter; defaults to console)
  - cd - change directory - used to change the current directory to the argument given
    - relative - ./, ../, ~/ - location to within the file system relative to the current directory
    - absolute - C:.... - location within the file system relative to the root directory
  - rm - remove - removes a file, directory, or symbolic link - file which points to another file or directory
    - rm -i : interactive deletion
    - rm -f : force deletion
    - rm -r : recursive deletion
  - pwd - print the current working directory
  - mv - moves a file or folder to the given location. Can also change the name of a file if given a different file name than the one being moved
  - cp - copies a file to the location given. similiar to mv in that it can also rename files
  - nano/vim - text editor thats provided by the bash to allow for users to edit files
  - rmdir - removes a directory.
  - echo - outputs a given string to stdout , which defaults to the console
  - clear - used to bring the command line on top of the terminal, i.e. it clears the terminal
  - man - manual page - form of software documentation found on the UNIX operating system

  Where to go when you don't know something

  - bash commands : use the --help flag for commmands to get information on the functionality of a command. you can also use the man command.
  - C# : use microsoft's documentation
  - GIT : use the --help flag for git commands for information on commands or consult git scm
