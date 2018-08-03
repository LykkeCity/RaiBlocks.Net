﻿using RaiBlocks.Actions;
using RaiBlocks.Results;
using RaiBlocks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaiBlocks
{
    /// <summary>
    /// .NET wrapper for RaiBlocks RPC Protocol.
    /// <see cref="https://github.com/clemahieu/raiblocks/wiki/RPC-protocol"/>
    /// </summary>
    public class RaiBlocksRpc
    {
        Uri _node;

        /// <param name="node">The URI of your node. http://localhost:7076/ by default.</param>
        public RaiBlocksRpc(Uri node)
        {
            _node = node ?? throw new ArgumentNullException(nameof(node));
        }

        /// <param name="url">The URI of your node. http://localhost:7076/ by default.</param>
        public RaiBlocksRpc(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            _node = new Uri(url);
        }

        #region Actions

        /// <summary>
        /// Returns how many RAW is owned and how many have not yet been received by account.
        /// </summary>
        /// <param name="acc">The account to get balance for.</param>
        /// <returns>Balance of <paramref name="acc"/> in RAW.</returns>
        public async Task<BalanceResult> GetBalanceAsync(RaiAddress acc)
        {
            var action = new GetBalance(acc);
            var handler = new ActionHandler<GetBalance, BalanceResult>(_node);
            return await handler.Handle(action);
        }

        public async Task<BalancesResult> GetBalancesAsync(IEnumerable<RaiAddress> acc)
        {
            var action = new GetBalances(acc);
            var handler = new ActionHandler<GetBalances, BalancesResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Get number of blocks for a specific account
        /// </summary>
        /// <param name="acc">The account to get block count for.</param>
        /// <returns>Number of blocks on account.</returns>
        public async Task<AccountBlockCountResult> GetAccountBlockCountAsync(RaiAddress acc)
        {
            var action = new GetAccountBlockCount(acc);
            var handler = new ActionHandler<GetAccountBlockCount, AccountBlockCountResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Returns frontier, open block, change representative block, balance, last modified timestamp from local database & block count for account
        /// </summary>
        public async Task<AccountInformationResult> GetAccountInformationAsync(RaiAddress acc)
        {
            var action = new GetAccountInformation(acc);
            var handler = new ActionHandler<GetAccountInformation, AccountInformationResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Return block by hash.
        /// </summary>
        /// <param name="hash">Block hash.</param>
        /// <returns>Block info.</returns>
        public async Task<RetrieveBlockResult> GetRetrieveBlockAsync(string hash)
        {
            var action = new Actions.RetrieveBlock
            {
                Hash = hash
            };
            var handler = new ActionHandler<Actions.RetrieveBlock, RetrieveBlockResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Get blocks info
        /// </summary>
        /// <param name="hashes">Blocks hashes.</param>
        /// <param name="pending">Include panding info</param>
        /// <param name="source">Include source info</param>
        /// <param name="balance">Include balance info</param>
        /// <returns>Block info.</returns>
        public async Task<RetrieveBlocksInfoResult> GetRetrieveBlocksInfoAsync(List<string> hashes,
            bool pending = false,
            bool source = false, bool balance = false)
        {
            var action = new RetrieveBlocksInfo
            {
                Hashes = hashes,
                Balance = balance,
                Pending = pending,
                Source = source
            };
            var handler = new ActionHandler<RetrieveBlocksInfo, RetrieveBlocksInfoResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// enable_control required
        // Creates a new account, insert next deterministic key in wallet
        public async Task<CreateAccountResult> CreateAccountAsync(string wallet)
        {
            var action = new CreateAccount(wallet);
            var handler = new ActionHandler<CreateAccount, CreateAccountResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Get account number for the public key
        /// </summary>>
        public async Task<GetAccountByPublicKeyResult> GetAccountByPublicKeyAsync(string key)
        {
            var action = new GetAccountByPublicKey(key);
            var handler = new ActionHandler<GetAccountByPublicKey, GetAccountByPublicKeyResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Reports send/receive information for a account
        /// </summary>>
        public async Task<AccountHistoryResult> GetAccountHistoryAsync(RaiAddress acc, int count = 1, string head = null)
        {
            var action = new GetAccountHistory(acc, count, head);
            var handler = new ActionHandler<GetAccountHistory, AccountHistoryResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// enable_control required
        /// Send amount from source in wallet to destination
        /// </summary>
        /// <param name="wallet">Wallet</param>
        /// <param name="source">Source</param>create
        /// <param name="destination">Destination</param>
        /// <param name="amount">Amount in RAW.</param>
        /// <returns></returns>
        public async Task<SendResult> SendAsync(string wallet, RaiAddress source, RaiAddress destination,
            RaiUnits.RaiRaw amount)
        {
            var action = new Send(wallet, source, destination, amount);
            var handler = new ActionHandler<Send, SendResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Validate account action
        /// </summary>
        /// <param name="acc">Account</param>
        /// <returns>Validate result <see cref="ValidateAccountResult"/></returns>
        public async Task<ValidateAccountResult> ValidateAccountAsync(RaiAddress acc)
        {
            var action = new ValidateAccount(acc);
            var handler = new ActionHandler<ValidateAccount, ValidateAccountResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Process block action
        /// </summary>
        /// <param name="block">Block</param>
        /// <returns>Block hash <see cref="ProcessBlockResult"/></returns>
        public async Task<ProcessBlockResult> ProcessBlockAsync(string block)
        {
            var action = new ProcessBlock(block);
            var handler = new ActionHandler<ProcessBlock, ProcessBlockResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Work generate action
        /// </summary>
        /// <param name="hash">Block hash</param>
        /// <returns>Generated work <see cref="WorkGenerateResult"/></returns>
        public async Task<WorkGenerateResult> GetWorkAsync(string hash)
        {
            var action = new WorkGenerate(hash);
            var handler = new ActionHandler<WorkGenerate, WorkGenerateResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Get account key
        /// </summary>
        /// <param name="account">Account</param>
        /// <returns>Ket <see cref="AccountKeyResult"/></returns>
        public async Task<AccountKeyResult> GetAccountKeyAsync(RaiAddress account)
        {
            var action = new AccountKey
            {
                AccountNumber = account,
            };

            var handler = new ActionHandler<AccountKey, AccountKeyResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Create block action
        /// </summary>
        /// <param name="wallet">Wallet</param>
        /// <param name="account">Account</param>
        /// <param name="destination">Destination</param>
        /// <param name="balance">Balance</param>
        /// <param name="amount">Amount</param>
        /// <param name="previous">Previous block hash</param>
        /// <returns>Created block info <see cref="BlockCreateResult"/></returns>
        public async Task<BlockCreateResult> BlockCreateSendAsync(string wallet, RaiAddress account,
            RaiAddress destination, RaiUnits.RaiRaw balance, RaiUnits.RaiRaw amount, string previous)
        {
            var action = new BlockCreate
            {
                Type = BlockType.send,
                Wallet = wallet,
                AccountNumber = account,
                Destination = destination,
                Balance = balance,
                Amount = amount,
                Previous = previous
            };
            var handler = new ActionHandler<BlockCreate, BlockCreateResult>(_node);
            return await handler.Handle(action);
        }

        /// <summary>
        /// Returns a consecutive list of block hashes in the account chain starting at block up to count.
        /// Will list all blocks back to the open block of this chain when count is set to "-1".
        /// The requested block hash is included in the answer.
        /// </summary>
        /// <param name="block">Block hash</param>
        /// <param name="count">Block count</param>
        /// <returns>Chain <see cref="GetChainResult"/></returns>
        public async Task<GetChainResult> GetChainAsync(string block, long count = -1)
        {
            var action = new GetChain
            {
                Block = block,
                Count = count
            };
            var handler = new ActionHandler<GetChain, GetChainResult>(_node);
            return await handler.Handle(action);
        }
        
        /// <summary>
        /// Returns a list of block hashes which have not yet been received by these accounts
        /// </summary>
        /// <param name="accounts">List of accounts</param>
        /// <param name="count">Count</param>
        /// <param name="source">Is need return a list of pending block hashes with amount and source accounts</param>
        /// <returns>List of block hashes which have not yet been received by these accounts <see cref="AccountsPendingResult"/></returns>
        public async Task<AccountsPendingResult> GetAccountsPendingAsync(List<string> accounts, long count = -1, bool source = true)
        {
            var action = new AccountsPending
            {
                Accounts = accounts,
                Source = source,
                Count = count,
                
            };
            var handler = new ActionHandler<AccountsPending, AccountsPendingResult>(_node);
            return await handler.Handle(action);
        }
        
        public async Task<BlockAccountResult> GetBlockAccountAsync(string hash)
        {
            var action = new BlockAccount
            {
                Hash = hash
            };
            var handler = new ActionHandler<BlockAccount, BlockAccountResult>(_node);
            return await handler.Handle(action);
        }

        #endregion
    }
}
