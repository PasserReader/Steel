using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensorflow;
using Tensorflow.Keras;
using static Tensorflow.Binding;
using NumSharp;


namespace WindowsApplication.Utility
{
    class SharpNetWork
    {

        public string CreateLinerRegression(NDArray trainX, NDArray trainY)
        {
            tf.compat.v1.disable_eager_execution();


            var x = tf.placeholder(tf.float32);
            var y = tf.placeholder(tf.float32);



            Tensor w = tf.Variable(0.1f, name: "weight");
            Tensor b = tf.Variable(1.0f, name: "bias");


            Tensor pred = tf.add(tf.multiply(x, w), b);
            
            Tensor cost = tf.reduce_sum(tf.square(pred - y)) / trainX.shape[0];

            var optimizer = tf.train.GradientDescentOptimizer(0.1f).minimize(cost);

            var init = tf.global_variables_initializer();

            using var sess = tf.Session();
            sess.run(init);


            string result = "";

            for (int epoch = 0; epoch < 100; epoch++)
            {
                foreach (var (xt, yt) in zip<float>(trainX, trainY))
                    sess.run(optimizer, (x, xt), (y, yt));

                // Display logs per epoch step
                if ((epoch + 1) % 1 == 0)
                {
                    var c = sess.run(cost, (x, trainX), (y, trainY));
                    result += "Epoch: " + epoch.ToString() + " Cost: " + c.ToString()
                        + " Weight: " + sess.run(w).ToString() + " Bias: " + sess.run(b).ToString() + "\n";
                }
            }

            return result;
        }

        
        public void CreateNet()
        {
            
        }

    }

}
