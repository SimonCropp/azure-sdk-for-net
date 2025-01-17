// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing a collection of <see cref="AgentPoolResource" /> and their operations.
    /// Each <see cref="AgentPoolResource" /> in the collection will belong to the same instance of <see cref="KubernetesClusterResource" />.
    /// To get an <see cref="AgentPoolCollection" /> instance call the GetAgentPools method from an instance of <see cref="KubernetesClusterResource" />.
    /// </summary>
    public partial class AgentPoolCollection : ArmCollection, IEnumerable<AgentPoolResource>, IAsyncEnumerable<AgentPoolResource>
    {
        private readonly ClientDiagnostics _agentPoolClientDiagnostics;
        private readonly AgentPoolsRestOperations _agentPoolRestClient;

        /// <summary> Initializes a new instance of the <see cref="AgentPoolCollection"/> class for mocking. </summary>
        protected AgentPoolCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AgentPoolCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AgentPoolCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _agentPoolClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.NetworkCloud", AgentPoolResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(AgentPoolResource.ResourceType, out string agentPoolApiVersion);
            _agentPoolRestClient = new AgentPoolsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, agentPoolApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != KubernetesClusterResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, KubernetesClusterResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create a new Kubernetes cluster agent pool or update the properties of the existing one.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="agentPoolName"> The name of the Kubernetes cluster agent pool. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<AgentPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string agentPoolName, AgentPoolData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agentPoolName, nameof(agentPoolName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _agentPoolClientDiagnostics.CreateScope("AgentPoolCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _agentPoolRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, agentPoolName, data, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkCloudArmOperation<AgentPoolResource>(new AgentPoolOperationSource(Client), _agentPoolClientDiagnostics, Pipeline, _agentPoolRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, agentPoolName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create a new Kubernetes cluster agent pool or update the properties of the existing one.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="agentPoolName"> The name of the Kubernetes cluster agent pool. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<AgentPoolResource> CreateOrUpdate(WaitUntil waitUntil, string agentPoolName, AgentPoolData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agentPoolName, nameof(agentPoolName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _agentPoolClientDiagnostics.CreateScope("AgentPoolCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _agentPoolRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, agentPoolName, data, cancellationToken);
                var operation = new NetworkCloudArmOperation<AgentPoolResource>(new AgentPoolOperationSource(Client), _agentPoolClientDiagnostics, Pipeline, _agentPoolRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, agentPoolName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get properties of the provided Kubernetes cluster agent pool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentPoolName"> The name of the Kubernetes cluster agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> is null. </exception>
        public virtual async Task<Response<AgentPoolResource>> GetAsync(string agentPoolName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agentPoolName, nameof(agentPoolName));

            using var scope = _agentPoolClientDiagnostics.CreateScope("AgentPoolCollection.Get");
            scope.Start();
            try
            {
                var response = await _agentPoolRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, agentPoolName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AgentPoolResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get properties of the provided Kubernetes cluster agent pool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentPoolName"> The name of the Kubernetes cluster agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> is null. </exception>
        public virtual Response<AgentPoolResource> Get(string agentPoolName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agentPoolName, nameof(agentPoolName));

            using var scope = _agentPoolClientDiagnostics.CreateScope("AgentPoolCollection.Get");
            scope.Start();
            try
            {
                var response = _agentPoolRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, agentPoolName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AgentPoolResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a list of agent pools for the provided Kubernetes cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_ListByKubernetesCluster</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AgentPoolResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AgentPoolResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _agentPoolRestClient.CreateListByKubernetesClusterRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _agentPoolRestClient.CreateListByKubernetesClusterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new AgentPoolResource(Client, AgentPoolData.DeserializeAgentPoolData(e)), _agentPoolClientDiagnostics, Pipeline, "AgentPoolCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Get a list of agent pools for the provided Kubernetes cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/agentPools</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_ListByKubernetesCluster</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AgentPoolResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AgentPoolResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _agentPoolRestClient.CreateListByKubernetesClusterRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _agentPoolRestClient.CreateListByKubernetesClusterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new AgentPoolResource(Client, AgentPoolData.DeserializeAgentPoolData(e)), _agentPoolClientDiagnostics, Pipeline, "AgentPoolCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentPoolName"> The name of the Kubernetes cluster agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string agentPoolName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agentPoolName, nameof(agentPoolName));

            using var scope = _agentPoolClientDiagnostics.CreateScope("AgentPoolCollection.Exists");
            scope.Start();
            try
            {
                var response = await _agentPoolRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, agentPoolName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/kubernetesClusters/{kubernetesClusterName}/agentPools/{agentPoolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AgentPools_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="agentPoolName"> The name of the Kubernetes cluster agent pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> is null. </exception>
        public virtual Response<bool> Exists(string agentPoolName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agentPoolName, nameof(agentPoolName));

            using var scope = _agentPoolClientDiagnostics.CreateScope("AgentPoolCollection.Exists");
            scope.Start();
            try
            {
                var response = _agentPoolRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, agentPoolName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AgentPoolResource> IEnumerable<AgentPoolResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AgentPoolResource> IAsyncEnumerable<AgentPoolResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
