﻿using System.Collections.Generic;
using NUnit.Framework;
using System.Threading.Tasks;
using RaiBlocks.ValueObjects;

namespace RaiBlocks.Tests
{
    [TestFixture, Explicit]
    public class RaiBlocksRpcExplicitTests
    {
        private RaiBlocksRpc _node = new RaiBlocksRpc("http://localhost:7076/");

        private RaiAddress _address =
            new RaiAddress("xrb_1q3hqecaw15cjt7thbtxu3pbzr1eihtzzpzxguoc37bj1wc5ffoh7w74gi6p");

        private string hash = "";

        [Test]
        public async Task GetBalanceAsync()
        {
            var x = await _node.GetBalanceAsync(_address);
        }

        [Test]
        public async Task GetAccountBlockCount()
        {
            var x = await _node.GetAccountBlockCountAsync(_address);
        }

        [Test]
        public async Task GetAccountInformation()
        {
            var x = await _node.GetAccountInformationAsync(_address);
        }

        [Test]
        public async Task GetAccountHistory()
        {
            var x = await _node.GetAccountHistoryAsync(_address, 1);
            Assert.AreEqual(x.Error, null);
            Assert.AreNotEqual(x.Entries, null);
        }

        [Test]
        public async Task GetChain()
        {
            var x = await _node.GetChainAsync(hash, -1);
        }

        [Test]
        public async Task GetAccountsPending()
        {
            var x = await _node.GetAccountsPendingAsync(new List<string> {_address}, -1, true);
        }
        
        [Test]
        public async Task GetAccountsPendingWork()
        {
            var x = await _node.GetWorkAsync(hash);
            Assert.AreNotEqual(x, null);
            Assert.AreNotEqual(x.Work, null);
        }
        
        [Test]
        public async Task GetAccountInfo()
        {
            var x = await _node.GetAccountInformationAsync(_address);
            Assert.AreNotEqual(x, null);
            Assert.AreEqual(x.Representative, null);
            Assert.AreEqual(x.Weight, null);
            Assert.AreEqual(x.Pending, null);
            
            x = await _node.GetAccountInformationAsync(_address, true);
            Assert.AreNotEqual(x, null);
            Assert.AreNotEqual(x.Representative, null);
            Assert.AreEqual(x.Weight, null);
            Assert.AreEqual(x.Pending, null);
            
            x = await _node.GetAccountInformationAsync(_address, true, true);
            Assert.AreNotEqual(x, null);
            Assert.AreNotEqual(x.Representative, null);
            Assert.AreNotEqual(x.Weight, null);
            Assert.AreEqual(x.Pending, null);
            
            x = await _node.GetAccountInformationAsync(_address, true, true, true);
            Assert.AreNotEqual(x, null);
            Assert.AreNotEqual(x.Representative, null);
            Assert.AreNotEqual(x.Weight, null);
            Assert.AreNotEqual(x.Pending, null);
        }
    }
}
