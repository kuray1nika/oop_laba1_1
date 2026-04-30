using System;
using System.Collections.Generic;

namespace proga_laba1_3
{
    /// <summary>
    /// Класс узла дерева. Каждый узел содержит значение и список потомков.
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// Значение узла
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Список дочерних узлов
        /// </summary>
        public List<TreeNode> Children { get; }

        /// <summary>
        /// Конструктор узла с заданным значением
        /// </summary>
        public TreeNode(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Children = new List<TreeNode>();
        }

        /// <summary>
        /// Добавление дочернего узла
        /// </summary>
        public void AddChild(TreeNode child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));

            Children.Add(child);
        }

        /// <summary>
        /// Проверка, является ли узел листом (нет потомков)
        /// </summary>
        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        /// <summary>
        /// Добавление дочернего узла по значению (возвращает созданный узел для цепочки вызовов)
        /// </summary>
        public TreeNode AddChild(string value)
        {
            TreeNode child = new TreeNode(value);
            Children.Add(child);
            return child;
        }
    }
}