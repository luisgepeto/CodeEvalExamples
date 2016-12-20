import System.Environment (getArgs)

main = do
    [inpFile] <- getArgs    
    input <- readFile inpFile    
    putStrLn $ show (sumFromString (lines input))

sumFromString ::  [String] -> Int
sumFromString = foldl (\acc s -> (read s) + acc) 0