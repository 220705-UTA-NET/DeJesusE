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
      7. git fetch - downloads commits, files, and referances form a remote repository into your local repository without forcing you to merge the changes into your repository.
      8. git merge - incorporates changes from two different commits into the current branch
      9. git revert - creates a new commit that undoes changes made from a previous commit without modifying the project existing history

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
  - Access modifiers (public, private, internal, protected)
  - Data Types
    - Value vs. Reference types
  - Control Flow
  - Operators
    - Logical, Arithmetic, Comparative
  - Classes
    - Fields / States / Members
    - Methods
  - Namespaces
  - Branching/Conditional Statements
  - Exceptions
    - Throwing exceptions
    - Exception handling
  - Abstract classes
  - Overriding / Overloading
  - Type Conversion
  - Data structures: Arrays, Lists, stacks, queues
  - Memory Architecture
    - Stack/Heap
  - Constructor methods, : base()
- Bash
  - ls, mkdir, touch, cat, cd, rm, pwd, mv, cp, nano/vim, rmdir, echo, clear, man
