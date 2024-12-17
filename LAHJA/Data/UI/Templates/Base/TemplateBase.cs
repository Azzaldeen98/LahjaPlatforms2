using System.Collections;

namespace LAHJA.Data.UI.Templates.Base;


public  enum TypeTemplate
{
    Base
}


public  interface IBuilderApi<T,E>
{

    T CreateAsync(E data);
    //T DeleteAsync(E data);
    //T GetOneAsync(E data);
    //IEnumerable<T> GetAllAsync(int skip=0,int take=1);
}

public  interface IBuilderComponents<T,E>
{

}

public class BuilderApi<T, E> : IBuilderApi<T, E> 
{
    public T CreateAsync(E data)
    {
        throw new NotImplementedException();
    }

   
}

public class BuilderComponents<T, E> : IBuilderComponents<T, E>
{

}
public interface ITemplateBase<T,E>
{
    bool IsActive { set; get; }
    TypeTemplate Type { get; }
    T Map(E data);
    IBuilderComponents<T, E> BuilderComponents { set; get; }
    IBuilderApi<T, E> BuilderApi { set; get; }


}


public abstract class TemplateBase<T, E> : ITemplateBase<T, E>
{
    public bool IsActive { get; set; }
    public  TypeTemplate Type { get=> TypeTemplate.Base; }
    public IBuilderComponents<T, E> BuilderComponents { get; set; }
    public IBuilderApi<T, E> BuilderApi { get; set; }

    public abstract T Map(E data);
}




