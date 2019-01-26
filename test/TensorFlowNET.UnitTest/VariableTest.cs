﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tensorflow;
using NumSharp.Core;

namespace TensorFlowNET.UnitTest
{
    [TestClass]
    public class VariableTest : Python
    {
        [TestMethod]
        public void Initializer()
        {
            var x = tf.Variable(10, name: "x");
            
            using (var session = tf.Session())
            {
                session.run(x.initializer);
                var result = session.run(x);
                Assert.AreEqual(10, (int)result);
            }
        }

        [TestMethod]
        public void StringVar()
        {
            var mammal1 = tf.Variable("Elephant", "var1", tf.chars);
            var mammal2 = tf.Variable("Tiger");
        }

        [TestMethod]
        public void ScalarVar()
        {
            var x = tf.Variable(3);
            var y = tf.Variable(6f);
        }

        /// <summary>
        /// https://databricks.com/tensorflow/variables
        /// </summary>
        [TestMethod]
        public void Add()
        {
            var x = tf.Variable(10, name: "x");

            var model = tf.global_variables_initializer();

            using (var session = tf.Session())
            {
                session.run(x.initializer);
                for(int i = 0; i < 5; i++)
                {
                    var x1 = x + 1;
                    var result = session.run(x1);
                    print(result);
                }
            }
        }
    }
}
