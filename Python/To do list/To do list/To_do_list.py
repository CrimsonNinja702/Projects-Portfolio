class Node: # Creating the empty nodes
    def __init__(self, data=None, next=None):
        self.data = data # Setting the data
        self.next = next

class LinkedList: # Creating the linked list
    def __init__(self):
        self.head = None

    def insert_at_beginning(self, data): # Insert node at beginning
        node = Node(data, self.head) # Creates a node with the given data and a new head
        self.head = node # Populates the node head with the node data

    def printList(self):
        if self.head is None: # Checking if list is empty
            print("Linked list is empty")
            return

        i = self.head # Starting from the head to iterate through list
        listStr = ""
        print("\nTASKS:\n-------\n")

        while i: # Moving through all iterations
            listStr += str(i.data) + "\n" # Appending data to the list
            i = i.next # Moving to next value
            
        print(listStr)

    def insert_at_end(self, data): # Insert node at end
        if self.head is None: 
            self.head = Node(data, None) # if node has no head/data, add data in. Since data is added at end, None follows after data in Node() as the next element will be null
            return

        i = self.head
        while i.next: # If i.next has a value it means we're not at the end
            i = i.next

        i.next = Node(data, None) # Since we're at the last element it meant the next node was empty, now we are populating it (tail created)

    def insert_values(self, data_list): # Inserts a list of values
        for data in data_list: # Iterating through the data list
            self.insert_at_end(data)

    def get_length(self):
        count = 0 # Stores number of items. Initiated to zero
        i = self.head
        while i:
            count +=1 # Increasing count for each item in the list
            i = i.next

        return count

    def remove_at(self, index):
        if index < 0 or index >= self.get_length(): # Checking if index is within boundary
            raise Exception("Invalid index")

        if index == 0:
            self.head = self.head.next # Points to the next element
            return

        count = 0
        i = self.head
        while i:
            if count == index - 1: # Stops at previous element
                i.next = i.next.next # Points to the element after the one to be removed
                break

            i = i.next
            count +=1

    def insert_at(self, index, data): # Inserts data at a specific index 
        if index < 0 or index >= self.get_length(): # Checking if index is within boundary
            raise Exception("Invalid index")

        if index == 0:
            self.insert_at_beginning(data)
            return

        count = 0
        i = self.head
        while i:
            if  count == index - 1:
                node = Node(data, i.next) # Adding the information. The index will be i.next as this would currently be at the previous element. TLDR: Sneaking it in between nodes
                i.next = node # Moves over the node
                break

            i = i.next
            count +=1

    def menu(self):
        choice = 0

        while True: # Keeps displaying menu after choices until exit is selected

            print("""
        To do List!
        -----------

        Please select an option below:
    
        1. Add list of tasks
        2. Add task at beginning
        3. Add task at specific location
        4. Remove task at specific location
        5. Get number of tasks
        6. Exit
        """)

            choice = int(input("Enter your choice: ")) # Stores the user's choice
    
            if choice == 1:
                x = 0
                itemList = []

                num = int(input("How many items would you like to add to the list? "))
                for x in range(num): # Iterating through number of items
                    item = input("Item to add: ")
                    itemList.append(item) # Appending each item
            
                self.insert_values(itemList)
                self.printList()

            if choice == 2:
                task = input("Please enter task to add to the beginning: ")
                self.insert_at_beginning(task)
                self.printList()

            if choice == 3:
                task = input("What task would you like to add: ")
                taskNum = int(input("Which position would you like this task in: "))
                self.insert_at(taskNum -1, task) # Minus one as the user will not be aware of how programming indexes work
                self.printList()

            if choice == 4:
                taskNum = int(input("Which task would you like to remove (by number): "))
                self.remove_at(taskNum -1)
                self.printList()

            if choice == 5:
                length = self.get_length()
                print(f"length is: {length}")

            elif choice == 6:
                print("Exiting...")
                break # Ends the loop
            
            self.menu


if __name__ == "__main__":
    ll = LinkedList() # Instantiating the class
    ll.menu() # Calling a function based on the class
 