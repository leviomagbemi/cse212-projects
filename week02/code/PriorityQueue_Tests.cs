using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following Value and priority and return in order of higest priority or FIFO if higest priority clashes: Game (2), Family (10), Studies (10), Work (8), Hangout (6)
    // Expected Result: family, studies, work, friendsHangout, game
    // Defect(s) Found: HighPriorityIndex was being set to index even when the previous priority value is the same with the priority at the current iteration. This will make the queue not to return the same highest priority in the right order(FIFO)
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        var game = new PriorityItem("Game", 2);
        var family = new PriorityItem("Family", 10);
        var studies = new PriorityItem("Studies", 10);
        var work = new PriorityItem("Work", 8);
        var friendsHangout = new PriorityItem("Hangout", 6);

        priorityQueue.Enqueue(game.Value, game.Priority);
        priorityQueue.Enqueue(work.Value, work.Priority);
        priorityQueue.Enqueue(friendsHangout.Value, friendsHangout.Priority);
        priorityQueue.Enqueue(family.Value, family.Priority);
        priorityQueue.Enqueue(studies.Value, studies.Priority);

        PriorityItem[] priorities = [family, studies, work, friendsHangout, game];

        for (int i = 0; i < priorities.Length; i++)
        {
            string priority = priorityQueue.Dequeue();
            Assert.AreEqual(priorities[i].Value, priority);
        }
    }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}