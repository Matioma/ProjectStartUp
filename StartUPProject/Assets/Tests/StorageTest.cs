using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StorageTest
{
    [Test]
    public void Storage_Get_Resource_Method_Works()
    {
        Storage storage = new Storage(10, 20, 50);

        Assert.IsTrue(storage.getBalance(ResourceType.Gold) == 10);
        Assert.IsTrue(storage.getBalance(ResourceType.Oranges) == 20);
        Assert.IsTrue(storage.getBalance(ResourceType.Wood) == 50);
    }
    [Test]
    public void Storage_Add_Resource_Method_Works()
    {
        Storage storage = new Storage(10, 20, 50);
        storage.AddResource(ResourceType.Gold, 120);
        storage.AddResource(ResourceType.Wood, 150);
        storage.AddResource(ResourceType.Oranges, 0);

        Assert.IsTrue(storage.getBalance(ResourceType.Gold) == 130);
        Assert.IsTrue(storage.getBalance(ResourceType.Oranges) == 20);
        Assert.IsTrue(storage.getBalance(ResourceType.Wood) == 200);
    }


    [Test]
    public void Storage_Add_Resource_Forbits_adding_Negative_amount()
    {
        Storage storage = new Storage(10, 20, 50);
        storage.AddResource(ResourceType.Gold, -1);

        Assert.IsFalse(storage.AddResource(ResourceType.Gold, -1));
        Assert.IsTrue(storage.getBalance(ResourceType.Gold)==10);
    }

    [Test]
    public void Storage_User_Resource_Forbits_spending_More_than_has()
    {
        Storage storage = new Storage(10, 20, 50);

        Assert.IsFalse(storage.UseResources(ResourceType.Gold, 100));
        Assert.IsTrue(storage.getBalance(ResourceType.Gold) == 10);
    }

}
