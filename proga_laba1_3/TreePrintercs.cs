using proga_laba1_3;
using System;
using System.Collections.Generic;

namespace proga_laba1_3
{
    /// <summary>
    /// Вспомогательный класс для вывода дерева
    /// </summary>
    public static class TreePrinter
    {
        /// <summary>
        /// Вывод всего дерева с отступами (рекурсивный обход в глубину)
        /// </summary>
        public static void PrintTree(TreeNode node, string indent = "")
        {
            if (node == null)
                return;

            Console.WriteLine($"{indent}{node.Value}");

            foreach (TreeNode child in node.Children)
            {
                PrintTree(child, indent + "    ");
            }
        }

        /// <summary>
        /// Вывод только листовых узлов
        /// </summary>
        public static void PrintLeaves(TreeNode node)
        {
            List<string> leaves = new List<string>();
            CollectLeaves(node, leaves);

            if (leaves.Count == 0)
            {
                Console.WriteLine("Дерево не содержит листьев (пустое или только корень без потомков?).");
                return;
            }

            Console.WriteLine("Найденные листья:");
            foreach (string leaf in leaves)
            {
                Console.WriteLine($"   {leaf}");
            }
        }

        /// <summary>
        /// Рекурсивный сбор всех листовых узлов
        /// </summary>
        private static void CollectLeaves(TreeNode node, List<string> leaves)
        {
            if (node == null)
                return;

            if (node.IsLeaf())
            {
                leaves.Add(node.Value);
            }
            else
            {
                foreach (TreeNode child in node.Children)
                {
                    CollectLeaves(child, leaves);
                }
            }
        }

        /// <summary>
        /// Подсчёт общего количества узлов в поддереве (включая текущий)
        /// </summary>
        public static int CountNodes(TreeNode node)
        {
            if (node == null)
                return 0;

            int count = 1; // Текущий узел
            foreach (TreeNode child in node.Children)
            {
                count += CountNodes(child);
            }
            return count;
        }

        /// <summary>
        /// Подсчёт количества листьев в поддереве
        /// </summary>
        public static int CountLeaves(TreeNode node)
        {
            if (node == null)
                return 0;

            if (node.IsLeaf())
                return 1;

            int count = 0;
            foreach (TreeNode child in node.Children)
            {
                count += CountLeaves(child);
            }
            return count;
        }
    }
}