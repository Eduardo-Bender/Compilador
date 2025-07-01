// Generated from c:/Users/eduar/Desktop/Distribuidos/Compilador/Compilador/Fortall.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link FortallParser}.
 */
public interface FortallListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link FortallParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(FortallParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(FortallParser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#line}.
	 * @param ctx the parse tree
	 */
	void enterLine(FortallParser.LineContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#line}.
	 * @param ctx the parse tree
	 */
	void exitLine(FortallParser.LineContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(FortallParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(FortallParser.StatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#ifBlock}.
	 * @param ctx the parse tree
	 */
	void enterIfBlock(FortallParser.IfBlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#ifBlock}.
	 * @param ctx the parse tree
	 */
	void exitIfBlock(FortallParser.IfBlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#elseIfBlock}.
	 * @param ctx the parse tree
	 */
	void enterElseIfBlock(FortallParser.ElseIfBlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#elseIfBlock}.
	 * @param ctx the parse tree
	 */
	void exitElseIfBlock(FortallParser.ElseIfBlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#whileBlock}.
	 * @param ctx the parse tree
	 */
	void enterWhileBlock(FortallParser.WhileBlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#whileBlock}.
	 * @param ctx the parse tree
	 */
	void exitWhileBlock(FortallParser.WhileBlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#assignment}.
	 * @param ctx the parse tree
	 */
	void enterAssignment(FortallParser.AssignmentContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#assignment}.
	 * @param ctx the parse tree
	 */
	void exitAssignment(FortallParser.AssignmentContext ctx);
	/**
	 * Enter a parse tree produced by the {@code negationExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterNegationExpression(FortallParser.NegationExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code negationExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitNegationExpression(FortallParser.NegationExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code parenthesizedExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterParenthesizedExpression(FortallParser.ParenthesizedExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code parenthesizedExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitParenthesizedExpression(FortallParser.ParenthesizedExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code constantExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterConstantExpression(FortallParser.ConstantExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code constantExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitConstantExpression(FortallParser.ConstantExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code additiveExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterAdditiveExpression(FortallParser.AdditiveExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code additiveExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitAdditiveExpression(FortallParser.AdditiveExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code identifierExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterIdentifierExpression(FortallParser.IdentifierExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code identifierExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitIdentifierExpression(FortallParser.IdentifierExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code comparisonExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterComparisonExpression(FortallParser.ComparisonExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code comparisonExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitComparisonExpression(FortallParser.ComparisonExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code multiplicativeExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterMultiplicativeExpression(FortallParser.MultiplicativeExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code multiplicativeExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitMultiplicativeExpression(FortallParser.MultiplicativeExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code booleanExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterBooleanExpression(FortallParser.BooleanExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code booleanExpression}
	 * labeled alternative in {@link FortallParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitBooleanExpression(FortallParser.BooleanExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#multOp}.
	 * @param ctx the parse tree
	 */
	void enterMultOp(FortallParser.MultOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#multOp}.
	 * @param ctx the parse tree
	 */
	void exitMultOp(FortallParser.MultOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#addOp}.
	 * @param ctx the parse tree
	 */
	void enterAddOp(FortallParser.AddOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#addOp}.
	 * @param ctx the parse tree
	 */
	void exitAddOp(FortallParser.AddOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#compOp}.
	 * @param ctx the parse tree
	 */
	void enterCompOp(FortallParser.CompOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#compOp}.
	 * @param ctx the parse tree
	 */
	void exitCompOp(FortallParser.CompOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#boolOp}.
	 * @param ctx the parse tree
	 */
	void enterBoolOp(FortallParser.BoolOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#boolOp}.
	 * @param ctx the parse tree
	 */
	void exitBoolOp(FortallParser.BoolOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#constant}.
	 * @param ctx the parse tree
	 */
	void enterConstant(FortallParser.ConstantContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#constant}.
	 * @param ctx the parse tree
	 */
	void exitConstant(FortallParser.ConstantContext ctx);
	/**
	 * Enter a parse tree produced by {@link FortallParser#block}.
	 * @param ctx the parse tree
	 */
	void enterBlock(FortallParser.BlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link FortallParser#block}.
	 * @param ctx the parse tree
	 */
	void exitBlock(FortallParser.BlockContext ctx);
}