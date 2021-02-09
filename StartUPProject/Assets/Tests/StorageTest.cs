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

}
