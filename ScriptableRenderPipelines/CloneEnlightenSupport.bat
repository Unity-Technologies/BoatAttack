git init
git remote add origin -f https://github.com/Unity-Technologies/Graphics
git checkout -b universal/enlighten-suppport
git config core.sparsecheckout true
echo com.unity.render-pipelines.core/ >> .git/info/sparse-checkout
echo com.unity.render-pipelines.universal/ >> .git/info/sparse-checkout
echo com.unity.shadergraph/ >> .git/info/sparse-checkout
echo com.unity.visualeffectgraph/ >> .git/info/sparse-checkout
git pull origin universal/enlighten-support