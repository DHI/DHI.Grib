namespace NGrib.Grib2.Templates;

public interface ITemplate
{
	bool TryGet<T>(TemplateContent<T> content, out T result);
}