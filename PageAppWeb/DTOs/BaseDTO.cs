using Mapster;

namespace PageAppWeb.DTOs;

public abstract class BaseDTO<TDto, TEntity> : IRegister
    where TEntity : class, new()
    where TDto : class, new()
{
    public TEntity ToEntity() => this.Adapt<TEntity>();
    public TEntity ToEntity(TEntity entity) => (this as TDto).Adapt<TEntity>();
    public static TDto FromEntity(TEntity entity) => entity.Adapt<TDto>();

    private TypeAdapterConfig Config { get; set; }

    public virtual void AddCustomMappings() { }

    protected TypeAdapterSetter<TDto, TEntity> SetCustomMappings()
      => Config.ForType<TDto, TEntity>();

    protected TypeAdapterSetter<TEntity, TDto> SetCustomMappingsInverse()
        => Config.ForType<TEntity, TDto>();

    public void Register(TypeAdapterConfig config)
    {
        Config = config;
        AddCustomMappings();
    }
}
