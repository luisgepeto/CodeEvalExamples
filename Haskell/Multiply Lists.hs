import System.Environment (getArgs)
import Data.List

main = do
    [inpFile] <- getArgs    
    input <- readFile inpFile        
    mapM_ multiplyLines $ lines input

multiplyLines :: String -> IO ()
multiplyLines line = do
    let Just pipeIndex = elemIndex '|' line
        (firstListRaw, '|':secondListRaw) = splitAt pipeIndex line
        [firstListAsString, secondListAsString] = map words [firstListRaw, secondListRaw]        
        multipliedList = zipWith (\x y -> show ((read x) * (read y))) firstListAsString secondListAsString
    putStrLn  $ unwords multipliedList