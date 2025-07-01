
namespace Compilador;

public class BasicFortallVisitor : FortallBaseVisitor<object?>
{
    private Dictionary<string, object?> Variables { get; } = new();

    public override object? VisitAssignment(FortallParser.AssignmentContext context)
    {
        var varName = context.ID().GetText();

        var value = Visit(context.expression());

        Variables[varName] = value;

        return null;
    }

    public override object? VisitConstant(FortallParser.ConstantContext context)
    {
        if (context.INTEGER() is { } i)
            return int.Parse(i.GetText());

        if (context.FLOAT() is { } f)
            return float.Parse(f.GetText());

        if (context.STRING() is { } s)
            return s.GetText()[1..^1];

        if (context.BOOL() is { } b)
            return b.GetText() == "true";

        if (context.NULL() is { })
            return null;

        throw new NotImplementedException();
    }

    public override object? VisitIdentifierExpression(FortallParser.IdentifierExpressionContext context)
    {
        var varName = context.ID().GetText();

        if (!Variables.ContainsKey(varName))
        {
            throw new Exception($"Vari�vel {varName} n�o est� definida");
        }

        return Variables[varName];
    }

    public override object? VisitAdditiveExpression(FortallParser.AdditiveExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));

        var op = context.addOp().GetText();
        return op switch
        {
            "+" => Add(left, right),
            "-" => Subtract(left, right),
            _ => throw new NotImplementedException()
        };
    }

    private object? Add(object? left, object? right)
    {
        if (left is int l && right is int r)
            return l + r;

        if (left is float lf && right is float rf)
            return lf + rf;

        if (left is int lInt && right is float rFloat)
            return lInt + rFloat;

        if (left is float lFloat && right is int rInt)
            return lFloat + rInt;

        throw new Exception($"Nao e possivel adicionar valores do tipo {left?.GetType()} e {right?.GetType()}.");
    }

    private object? Subtract(object? left, object? right)
    {
        if (left is int l && right is int r)
            return l - r;

        if (left is float lf && right is float rf)
            return lf - rf;

        if (left is int lInt && right is float rFloat)
            return lInt - rFloat;

        if (left is float lFloat && right is int rInt)
            return lFloat - rInt;

        throw new Exception($"Nao e possivel subtrair valores do tipo {left?.GetType()} e {right?.GetType()}.");
    }
}
