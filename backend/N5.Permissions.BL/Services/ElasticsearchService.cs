using N5.Permissions.BL.Interfaces;
using N5.Permissions.BL.Models;
using Nest;

namespace N5.Permissions.BL.Services;
public class ElasticsearchService : IElasticsearchService
{
    private readonly IElasticClient _elasticClient;

    public ElasticsearchService(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }

    public async Task IndexPermissionAsync(PermissionDto permissionDto)
    {
        await _elasticClient.IndexDocumentAsync(permissionDto);
    }
}
